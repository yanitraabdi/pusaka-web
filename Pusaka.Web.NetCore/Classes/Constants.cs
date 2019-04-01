using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Classes
{
    public static class Constants
    {
        public const string AzureFunctionClient = "AzureFunctionClient";
        public const string AzureFunctionKeyHeader = "x-functions-key";
        public const string PusakaAzureFunctionUrl = "AppConfig:PusakaAzureFunctionUrl";

        #region Azure Url

        public const string GetSchoolAzureFunctionConfig = "AppConfig:GetSchoolAzureFunctionConfig";
        public const string GetSchoolByIdAzureFunctionConfig = "AppConfig:GetSchoolByIdAzureFunctionConfig";
        public const string InsertSchoolAzureFunctionConfig = "AppConfig:InsertSchoolAzureFunctionConfig";
        public const string UpdateSchoolAzureFunctionConfig = "AppConfig:UpdateSchoolAzureFunctionConfig";
        public const string DeleteSchoolAzureFunctionConfig = "AppConfig:DeleteSchoolAzureFunctionConfig";
        
        public const string GetUserAzureFunctionConfig = "AppConfig:GetUserAzureFunctionConfig";
        public const string GetUserByIdAzureFunctionConfig = "AppConfig:GetUserByIdAzureFunctionConfig";
        public const string InsertUserAzureFunctionConfig = "AppConfig:InsertUserAzureFunctionConfig";
        public const string UpdateUserAzureFunctionConfig = "AppConfig:UpdateUserAzureFunctionConfig";
        public const string DeleteUserAzureFunctionConfig = "AppConfig:DeleteUserAzureFunctionConfig";

        public const string GetSchoolTypeAzureFunctionConfig = "AppConfig:GetSchoolTypeAzureFunctionConfig";
        public const string GetGenderAzureFunctionConfig = "AppConfig:GetGenderAzureFunctionConfig";
        public const string GetReligionAzureFunctionConfig = "AppConfig:GetReligionAzureFunctionConfig";

        #endregion

        #region Azure Key

        public const string GetSchoolAzureFunctionKeyConfig = "AzureKeyConfig:GetSchoolAzureFunctionKeyConfig";
        public const string GetSchoolByIdAzureFunctionKeyConfig = "AzureKeyConfig:GetSchoolByIdAzureFunctionKeyConfig";
        public const string InsertSchoolAzureFunctionKeyConfig = "AzureKeyConfig:InsertSchoolAzureFunctionKeyConfig";
        public const string UpdateSchoolAzureFunctionKeyConfig = "AzureKeyConfig:UpdateSchoolAzureFunctionKeyConfig";
        public const string DeleteSchoolAzureFunctionKeyConfig = "AzureKeyConfig:DeleteSchoolAzureFunctionKeyConfig";

        public const string GetUserAzureFunctionKeyConfig = "AzureKeyConfig:GetUserAzureFunctionKeyConfig";
        public const string GetUserByIdAzureFunctionKeyConfig = "AzureKeyConfig:GetUserByIdAzureFunctionKeyConfig";
        public const string InsertUserAzureFunctionKeyConfig = "AzureKeyConfig:InsertUserAzureFunctionKeyConfig";
        public const string UpdateUserAzureFunctionKeyConfig = "AzureKeyConfig:UpdateUserAzureFunctionKeyConfig";
        public const string DeleteUserAzureFunctionKeyConfig = "AzureKeyConfig:DeleteUserAzureFunctionKeyConfig";

        public const string GetAzureDefaultHostKeyConfig = "AzureKeyConfig:AzureDefaultHostKeyConfig";

        #endregion
    }
}
