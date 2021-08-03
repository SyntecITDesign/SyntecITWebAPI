using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SyntecITWebAPI.ParameterModels.GAS.Stationery
{


    public class UpsertStationeryQuantity
    {
        #region Public Properties

        public int ID {
            get;set;
        }

        public string StationeryName
        {
            get; set;
        }

        public string StationerySpec
        {
            get; set;
        }

        public string StationeryUnit
        {
            get; set;
        }

        public int StationeryAmount
        {
            get; set;
        }

        #endregion Public Properties
    }

    public class DeleteStationery
    {
        #region Public Properties


        public int ID
        {
            get; set;
        }


        #endregion Public Properties
    }
}
