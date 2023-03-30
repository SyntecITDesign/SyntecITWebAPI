using Newtonsoft.Json.Linq;
using SyntecITWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyntecITWebAPI.Common
{
	public class HttpHandler
	{
		#region Public Properties

		public static HttpHandler Instance
		{
			get
			{
				if( m_theInstance == null )
				{
					m_theInstance = new HttpHandler();
				}
				return m_theInstance;
			}
		}

		#endregion Public Properties

		#region Public Methods

		public async Task<ResponseHandler> GetRequestAsync( Dictionary<string, string> headerDictionary, Uri apiUri, CancellationTokenSource cancelSource = null )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			string responseBody = string.Empty;
			if( cancelSource == null )
			{
				cancelSource = new CancellationTokenSource();
			}

			HttpRequestMessage customRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = apiUri,
			};

			foreach( KeyValuePair<string, string> additionalHeaderInfo in headerDictionary )
			{
				customRequestMessage.Headers.Add( additionalHeaderInfo.Key, additionalHeaderInfo.Value );
			}

			Func<Task> requestAction = async () =>
			{
				HttpResponseMessage response = await m_CurrentClient.SendAsync( customRequestMessage, cancelSource.Token ).ConfigureAwait( false );
				response.EnsureSuccessStatusCode();
				responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait( false );

				JObject responseObject = JObject.Parse( responseBody );
				if( responseObject[ RETURN_STATUS ].ToString() == RETURN_SUCCESS_CODE )
				{
					responseHandler.Code = ErrorCodeList.Success;
					responseHandler.Content = responseObject[ RETURN_DATA ];
				}
				else
				{
					responseHandler.Code = ErrorCodeList.API_Internet_Error;
					responseHandler.Detail = responseObject[ RETURN_DATA ].ToString();
				}
			};

			await HttpClientSafeExecuteAsync( requestAction, nameof( GetRequestAsync ), cancelSource, responseHandler ).ConfigureAwait( false );

			return responseHandler;
		}

		public async Task<ResponseHandler> PostDownloadFileAsync( Dictionary<string, string> headerDictionary, Uri apiUri, string jsonBody, string fileRoute, CancellationTokenSource cancelSource = null )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			if( cancelSource == null )
			{
				cancelSource = new CancellationTokenSource();
			}

			HttpRequestMessage customRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = apiUri,
			};

			foreach( KeyValuePair<string, string> additionalHeaderInfo in headerDictionary )
			{
				customRequestMessage.Headers.Add( additionalHeaderInfo.Key, additionalHeaderInfo.Value );
			}

			customRequestMessage.Content = new StringContent( jsonBody, Encoding.UTF8, "application/json" );

			Func<Task> requestAction = async () =>
			{
				HttpResponseMessage response = await m_CurrentClient.SendAsync( customRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancelSource.Token ).ConfigureAwait( false );
				if( response.IsSuccessStatusCode == false )
				{
					//read error message from header
					HttpHeaders headers = response.Headers;
					IEnumerable<string> values;
					if( headers.TryGetValues( STREAM_STATUS_HEADER, out values ) )
					{
						string session = values.First();
						if( double.TryParse( session, out double parsevalue ) == false )
						{
							responseHandler.Code = ErrorCodeList.API_Internet_Error;
						}
						else
						{
							responseHandler.Code = (ErrorCodeList)parsevalue;
						}
					}
				}
				else
				{
					using( Stream saveStream = new FileStream( fileRoute, FileMode.Create, FileAccess.Write, FileShare.None ) )
					{
						await response.Content.CopyToAsync( saveStream ).ConfigureAwait( false );
						responseHandler.Code = ErrorCodeList.Success;
					}
				}
			};

			await HttpClientSafeExecuteAsync( requestAction, nameof( PostDownloadFileAsync ), cancelSource, responseHandler ).ConfigureAwait( false );

			return responseHandler;
		}

		public async Task<Stream> PostDownloadFileStreamAsync( Dictionary<string, string> headerDictionary, Uri apiUri, string jsonBody, string fileRoute, CancellationTokenSource cancelSource = null )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			if( cancelSource == null )
			{
				cancelSource = new CancellationTokenSource();
			}

			HttpRequestMessage customRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = apiUri,
			};

			foreach( KeyValuePair<string, string> additionalHeaderInfo in headerDictionary )
			{
				customRequestMessage.Headers.Add( additionalHeaderInfo.Key, additionalHeaderInfo.Value );
			}

			customRequestMessage.Content = new StringContent( jsonBody, Encoding.UTF8, "application/json" );

			HttpResponseMessage response = await m_CurrentClient.SendAsync( customRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancelSource.Token ).ConfigureAwait( false );

			
			if( response.IsSuccessStatusCode == false ) //Scloud API Error
			{
				return null;
			}
			else
			{
				return await response.Content.ReadAsStreamAsync();
			}
		}

		public async Task<ResponseHandler> PostJsonRequestAsync( Dictionary<string, string> headerDictionary, Uri apiUri, string jsonBody, CancellationTokenSource cancelSource = null )
		{
			ResponseHandler responseHandler = new ResponseHandler();
			string responseBody = "";
			if( cancelSource == null )
			{
				cancelSource = new CancellationTokenSource();
			}

			HttpRequestMessage customRequestMessage = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = apiUri,
			};

			foreach( KeyValuePair<string, string> additionalHeaderInfo in headerDictionary )
			{
				try
				{
					customRequestMessage.Headers.Add( additionalHeaderInfo.Key, additionalHeaderInfo.Value );
				}
				catch( Exception ex )
				{
					string test = ex.Message;
				}
			}

			customRequestMessage.Content = new StringContent( jsonBody, Encoding.UTF8, "application/json" );

			Func<Task> requestAction = async () =>
			{
				HttpResponseMessage response = await m_CurrentClient.SendAsync( customRequestMessage, cancelSource.Token ).ConfigureAwait( false );
				response.EnsureSuccessStatusCode();
				responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait( false );
				JObject responseObject = JObject.Parse( responseBody );

				if( responseObject[ RETURN_STATUS ].ToString() == RETURN_SUCCESS_CODE )
				{
					responseHandler.Code = ErrorCodeList.Success;
					responseHandler.Content = responseObject[ RETURN_DATA ];
				}
				else
				{
					responseHandler.Code = ErrorCodeList.API_Internet_Error;
					responseHandler.Detail = responseObject[ RETURN_DATA ].ToString();
				}
			};

			await HttpClientSafeExecuteAsync( requestAction, nameof( PostJsonRequestAsync ), cancelSource, responseHandler ).ConfigureAwait( false );

			return responseHandler;
		}

		public ResponseHandler SendFileStream( FileStream sourceStream, Dictionary<string, string> headerDictionary, Uri apiUri )
		{
			ResponseHandler returnResult = new ResponseHandler();

			string returnString = string.Empty;
			try
			{
				returnString = InnerSendFileStream( sourceStream, headerDictionary, apiUri );
				returnResult.Code = ErrorCodeList.Success;
				returnResult.Content = returnString;
			}
			catch( WebException e ) when( e.Status == WebExceptionStatus.Timeout )
			{
				// If we got here, it was a timeout exception
				string log = $"{nameof( SendFileStream )} :Timeout {e.ToString()}";
				returnResult.Code = ErrorCodeList.Time_Out;    //time out errorcode
				returnResult.Detail = log;
			}
			catch( Exception ex )
			{
				string log = $"{nameof( SendFileStream )} : {ex.ToString()}";
				returnResult.Detail = log;
			}
			return returnResult;
		}

		#endregion Public Methods

		#region Private Fields

		private static HttpClient m_CurrentClient = new HttpClient() { };

		//singleton pattern
		private static HttpHandler m_theInstance = null;

		private readonly int MAX_CHUNK_SIZE = ( 1024 * 5000 );
		private readonly string RETURN_DATA = "data";
		private readonly string RETURN_STATUS = "status";
		private readonly string RETURN_SUCCESS_CODE = "0";
		private readonly string STREAM_STATUS_HEADER = "Status";
		private readonly int UPLOAD_TIME_OUT = 600000;

		#endregion Private Fields

		#region Private Constructors + Destructors

		private HttpHandler()
		{
		}

		#endregion Private Constructors + Destructors

		#region Private Methods

		private async Task HttpClientSafeExecuteAsync( Func<Task> requestAction, string methodName, CancellationTokenSource cancelSource, ResponseHandler returnResult )
		{
			try
			{
				await requestAction().ConfigureAwait( false );
			}
			catch( TaskCanceledException CancelException )
			{
				string log = "";
				if( !cancelSource.Token.IsCancellationRequested )
				{
					// Timed Out
					log = $"{methodName} :TimeOut {CancelException.ToString()}";
					returnResult.Code = ErrorCodeList.Time_Out;    //time out errorcode
					returnResult.Detail = log;
				}
				else
				{
					// Cancelled for some other reason
					log = $"{methodName} :Cancel {CancelException.ToString()}";
					returnResult.Detail = log;
				}
			}
			catch( Exception ex )
			{
				string log = $"{methodName} : {ex.ToString()}";
				returnResult.Detail = log;
			}
		}

		private string InnerSendFileStream( FileStream sourceStream, Dictionary<string, string> headerDictionary, Uri apiUri )
		{
			byte[] byteFileArray;

			HttpWebRequest uploadWebRequest = (HttpWebRequest)WebRequest.Create( apiUri );
			uploadWebRequest.Method = "POST";

			//must set, otherwise the server will not know then to stop listening on the incoming data stream
			uploadWebRequest.ContentLength = sourceStream.Length;

			foreach( KeyValuePair<string, string> header in headerDictionary )
			{
				uploadWebRequest.Headers.Set( header.Key, header.Value );
			}

			//another way to send big file, just set SendChunked to true
			//https://zh.wikipedia.org/wiki/%E5%88%86%E5%9D%97%E4%BC%A0%E8%BE%93%E7%BC%96%E7%A0%81

			//m_UploadWebRequest.SendChunked = true;

			// The default value is 100,000 milliseconds (100 seconds).
			uploadWebRequest.Timeout = UPLOAD_TIME_OUT;
			uploadWebRequest.Credentials = CredentialCache.DefaultCredentials;
			uploadWebRequest.AllowWriteStreamBuffering = false;
			Stream RequestStream = uploadWebRequest.GetRequestStream();

			// cause overflow when use integer as type
			long fileSize = sourceStream.Length;
			long remainingBytes = fileSize;
			long numberOfBytesRead = 0;
			int doneBytes = 0;

			while( numberOfBytesRead < fileSize )
			{
				SetByteArray( out byteFileArray, remainingBytes );
				doneBytes = WriteFileToStreamAsync( byteFileArray, RequestStream, sourceStream ).Result;
				numberOfBytesRead += doneBytes;
				remainingBytes -= doneBytes;
			}

			RequestStream.Close();

			string response = "";
			using( WebResponse currentResponse = uploadWebRequest.GetResponse() )
			{
				using( StreamReader sr = new StreamReader( currentResponse.GetResponseStream(), Encoding.UTF8 ) )
				{
					response = sr.ReadToEnd();
				}
			}
			return response;
		}

		private void SetByteArray( out byte[] byteFileArray, long bytesLeft )
		{
			byteFileArray = bytesLeft < MAX_CHUNK_SIZE ? new byte[ bytesLeft ] : new byte[ MAX_CHUNK_SIZE ];
		}

		private async Task<int> WriteFileToStreamAsync( byte[] byteFileArray, Stream requestStream, FileStream sourceStream )
		{
			int nDoneBytes = await sourceStream.ReadAsync( byteFileArray, 0, byteFileArray.Length ).ConfigureAwait( false );
			await requestStream.WriteAsync( byteFileArray, 0, byteFileArray.Length ).ConfigureAwait( false );
			return nDoneBytes;
		}

		#endregion Private Methods
	}
}
