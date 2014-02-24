using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KreateIT.Data
{
    public class UserDAL
    {
        public static DataSet List()
        {
            return DAL.GetDataset("SELECT * FROM Users ORDER BY U_ID");
        }

        public static DataSet GetDetails(int UserID)
        {
            return DAL.GetDataset("SELECT * FROM Users WHERE U_ID = @UserID", new SQLArg("@UserID", UserID));
        }

        public static DataSet GetDetails(string UserName)
        {
            return DAL.GetDataset("SELECT * FROM Users WHERE U_Username = @UserName", new SQLArg("@UserName", UserName));
        }

        public static int GetIDFromUserName(string UserName)
        {
            return DAL.GetDataInt("SELECT U_ID FROM Users WHERE U_Username = @UserName", new SQLArg("@UserName", UserName));
        }

        public static int SaveOrUpdate
        (
            int ID, string Title, string UserName, string PasswordHash, string FirstName, 
            string LastName, string DistinguishingName, string EMail, string Moderator, bool isTutor, 
            bool isAdmin, DateTime? CreateDate, DateTime? LastAccessDate, bool AudioOn, string Key, 
            string Status, string ModType, int DiscAccess, string UserFieldString1, string UserFieldString2, 
            string UserFieldString3, string UserFieldString4, string UserFieldString5, DateTime? UserFieldDate1, DateTime? UserFieldDate2, 
            DateTime? UserFieldDate3, int UserFieldList1, int UserFieldList2, int UserFieldList3, string PasswordReset, 
            DateTime? PasswordResetDate, int FailedLogins, string NONCE, bool isPasswordHashed, string TempPassword,
            Guid Salt, string LDAP_UniqueID, string LDAP_GUID, string Domain, string DomainUsername, 
            bool isActiveDirectoryUser, string LanguageCode, string NetBIOSAccount, int GiftRegisterPermissionLevel, int GiftRegisterRegionID, 
            int GiftRegisterEntityID, Guid UserGUID, bool Dashboard, DateTime? LeavingDate, DateTime? RemovalDate, 
            int RemovalUserID, DateTime? StartDate, bool UserManagementAccess, bool UserEnrolmentAccess, bool ScheduledReportsAccess, 
            bool ThirdPartyDatabaseUser 
        )
        {
            int UserID = 0;
            string SQLFields = "";
            string SQLValues = "";
            List<SQLArg> args = new List<SQLArg>();

            if (ID == 0)
            {
                if (Title != default(string)) { SQLFields += "U_TITLE, "; SQLValues += "@Title, "; args.Add(new SQLArg("@Title", Title)); }
                if (UserName != default(string)) { SQLFields += "U_USERNAME, "; SQLValues += "@UserName, "; args.Add(new SQLArg("@UserName", UserName)); }
                if (PasswordHash != default(string)) { SQLFields += "U_PASSWORD, "; SQLValues += "@PasswordHash, "; args.Add(new SQLArg("@PasswordHash", PasswordHash)); }
                if (FirstName != default(string)) { SQLFields += "U_NAME_FIRST, "; SQLValues += "@FirstName, "; args.Add(new SQLArg("@FirstName", FirstName)); }
                if (LastName != default(string)) { SQLFields += "U_NAME_LAST, "; SQLValues += "@LastName, "; args.Add(new SQLArg("@LastName", LastName)); }
                if (DistinguishingName != default(string)) { SQLFields += "U_DN, "; SQLValues += "@DistinguishingName, "; args.Add(new SQLArg("@DistinguishingName", DistinguishingName)); }
                if (EMail != default(string)) { SQLFields += "U_EMAIL, "; SQLValues += "@EMail, "; args.Add(new SQLArg("@EMail", EMail)); }
                if (Moderator != default(string)) { SQLFields += "U_MODERATOR, "; SQLValues += "@Moderator, "; args.Add(new SQLArg("@Moderator", Moderator)); }
                if (isTutor != default(bool)) { SQLFields += "U_TUTOR, "; SQLValues += "@isTutor, "; args.Add(new SQLArg("@isTutor", (isTutor ? "y" : "n"))); }
                if (isAdmin != default(bool)) { SQLFields += "U_ADMIN, "; SQLValues += "@isAdmin, "; args.Add(new SQLArg("@isAdmin", (isAdmin ? "y" : "n"))); }
                if (CreateDate != default(DateTime?)) { SQLFields += "U_CREATE_DT, "; SQLValues += "@CreateDate, "; args.Add(new SQLArg("@CreateDate", CreateDate)); }
                if (LastAccessDate != default(DateTime?)) { SQLFields += "U_LACCESS_DT, "; SQLValues += "@LastAccessDate, "; args.Add(new SQLArg("@LastAccessDate", LastAccessDate)); }
                if (AudioOn != default(bool)) { SQLFields += "U_AUDIO_PREF, "; SQLValues += "@AudioOn, "; args.Add(new SQLArg("@AudioOn", (AudioOn ? 1 : 0))); }
                if (Key != default(string)) { SQLFields += "U_KEY, "; SQLValues += "@Key, "; args.Add(new SQLArg("@Key", Key)); }
                if (Status != default(string)) { SQLFields += "U_STATUS, "; SQLValues += "@Status, "; args.Add(new SQLArg("@Status", Status)); }
                if (ModType != default(string)) { SQLFields += "U_MOD_TYPE, "; SQLValues += "@ModType, "; args.Add(new SQLArg("@ModType", ModType)); }
                if (DiscAccess != default(int)) { SQLFields += "U_DISC_ACCESS, "; SQLValues += "@DiscAccess, "; args.Add(new SQLArg("@DiscAccess", DiscAccess)); }
                if (UserFieldString1 != default(string)) { SQLFields += "U_FIELD_STR_1, "; SQLValues += "@UserFieldString1, "; args.Add(new SQLArg("@UserFieldString1", UserFieldString1)); }
                if (UserFieldString2 != default(string)) { SQLFields += "U_FIELD_STR_2, "; SQLValues += "@UserFieldString2, "; args.Add(new SQLArg("@UserFieldString2", UserFieldString2)); }
                if (UserFieldString3 != default(string)) { SQLFields += "U_FIELD_STR_3, "; SQLValues += "@UserFieldString3, "; args.Add(new SQLArg("@UserFieldString3", UserFieldString3)); }
                if (UserFieldString4 != default(string)) { SQLFields += "U_FIELD_STR_4, "; SQLValues += "@UserFieldString4, "; args.Add(new SQLArg("@UserFieldString4", UserFieldString4)); }
                if (UserFieldString5 != default(string)) { SQLFields += "U_FIELD_STR_5, "; SQLValues += "@UserFieldString5, "; args.Add(new SQLArg("@UserFieldString5", UserFieldString5)); }
                if (UserFieldDate1 != default(DateTime?)) { SQLFields += "U_FIELD_DT_1, "; SQLValues += "@UserFieldDate1, "; args.Add(new SQLArg("@UserFieldDate1", UserFieldDate1)); }
                if (UserFieldDate2 != default(DateTime?)) { SQLFields += "U_FIELD_DT_2, "; SQLValues += "@UserFieldDate2, "; args.Add(new SQLArg("@UserFieldDate2", UserFieldDate2)); }
                if (UserFieldDate3 != default(DateTime?)) { SQLFields += "U_FIELD_DT_3, "; SQLValues += "@UserFieldDate3, "; args.Add(new SQLArg("@UserFieldDate3", UserFieldDate3)); }
                if (UserFieldList1 != default(int)) { SQLFields += "U_FIELD_LIST_1, "; SQLValues += "@UserFieldList1, "; args.Add(new SQLArg("@UserFieldList1", UserFieldList1)); }
                if (UserFieldList2 != default(int)) { SQLFields += "U_FIELD_LIST_2, "; SQLValues += "@UserFieldList2, "; args.Add(new SQLArg("@UserFieldList2", UserFieldList2)); }
                if (UserFieldList3 != default(int)) { SQLFields += "U_FIELD_LIST_3, "; SQLValues += "@UserFieldList3, "; args.Add(new SQLArg("@UserFieldList3", UserFieldList3)); }
                if (PasswordReset != default(string)) { SQLFields += "U_PASSWORD_RESET, "; SQLValues += "@PasswordReset, "; args.Add(new SQLArg("@PasswordReset", PasswordReset)); }
                if (PasswordResetDate != default(DateTime?)) { SQLFields += "U_PASS_RESET_TIME, "; SQLValues += "@PasswordResetDate, "; args.Add(new SQLArg("@PasswordResetDate", PasswordResetDate)); }
                if (FailedLogins != default(int)) { SQLFields += "U_FAILEDLOGINS, "; SQLValues += "@FailedLogins, "; args.Add(new SQLArg("@FailedLogins", FailedLogins)); }
                if (NONCE != default(string)) { SQLFields += "U_NONCE, "; SQLValues += "@NONCE, "; args.Add(new SQLArg("@NONCE", NONCE)); }
                if (isPasswordHashed != default(bool)) { SQLFields += "U_PASS_HASHED, "; SQLValues += "@isPasswordHashed, "; args.Add(new SQLArg("@isPasswordHashed", (isPasswordHashed ? 1 : 0))); }
                if (TempPassword != default(string)) { SQLFields += "U_P_TEMP, "; SQLValues += "@TempPassword, "; args.Add(new SQLArg("@TempPassword", TempPassword)); }
                if (Salt != default(Guid)) { SQLFields += "U_SALT, "; SQLValues += "@Salt, "; args.Add(new SQLArg("@Salt", Salt)); }
                if (LDAP_UniqueID != default(string)) { SQLFields += "U_LDAP_UNIQUEID, "; SQLValues += "@LDAP_UniqueID, "; args.Add(new SQLArg("@LDAP_UniqueID", LDAP_UniqueID)); }
                if (LDAP_GUID != default(string)) { SQLFields += "U_LDAP_GUID, "; SQLValues += "@LDAP_GUID, "; args.Add(new SQLArg("@LDAP_GUID", LDAP_GUID)); }
                if (Domain != default(string)) { SQLFields += "U_DOMAIN, "; SQLValues += "@Domain, "; args.Add(new SQLArg("@Domain", Domain)); }
                if (DomainUsername != default(string)) { SQLFields += "U_DOMAIN_UNAME, "; SQLValues += "@DomainUsername, "; args.Add(new SQLArg("@DomainUsername", DomainUsername)); }
                if (isActiveDirectoryUser != default(bool)) { SQLFields += "U_AD_USER, "; SQLValues += "@isActiveDirectoryUser, "; args.Add(new SQLArg("@isActiveDirectoryUser", (isActiveDirectoryUser ? "y" : "n"))); }
                if (LanguageCode != default(string)) { SQLFields += "U_LANG_CODE, "; SQLValues += "@LanguageCode, "; args.Add(new SQLArg("@LanguageCode", LanguageCode)); }
                if (NetBIOSAccount != default(string)) { SQLFields += "U_NETBIOS_ACCOUNT, "; SQLValues += "@NetBIOSAccount, "; args.Add(new SQLArg("@NetBIOSAccount", NetBIOSAccount)); }
                if (GiftRegisterPermissionLevel != default(int)) { SQLFields += "U_GRPL_ACCESS_ID, "; SQLValues += "@GiftRegisterPermissionLevel, "; args.Add(new SQLArg("@GiftRegisterPermissionLevel", GiftRegisterPermissionLevel)); }
                if (GiftRegisterRegionID != default(int)) { SQLFields += "U_GRR_ID, "; SQLValues += "@GiftRegisterRegionID, "; args.Add(new SQLArg("@GiftRegisterRegionID", GiftRegisterRegionID)); }
                if (GiftRegisterEntityID != default(int)) { SQLFields += "U_GRE_ID, "; SQLValues += "@GiftRegisterEntityID, "; args.Add(new SQLArg("@GiftRegisterEntityID", GiftRegisterEntityID)); }
                if (UserGUID != default(Guid)) { SQLFields += "U_GUID, "; SQLValues += "@UserGUID, "; args.Add(new SQLArg("@UserGUID", UserGUID)); }
                if (Dashboard != default(bool)) { SQLFields += "U_DASHBOARD, "; SQLValues += "@Dashboard, "; args.Add(new SQLArg("@Dashboard", Dashboard ? 'y' : 'n')); }
                if (LeavingDate != default(DateTime?)) { SQLFields += "U_LEAVE_DT, "; SQLValues += "@LeavingDate, "; args.Add(new SQLArg("@LeavingDate", LeavingDate)); }
                if (RemovalDate != default(DateTime?)) { SQLFields += "U_REMOVE_DT, "; SQLValues += "@RemovalDate, "; args.Add(new SQLArg("@RemovalDate", RemovalDate)); }
                if (RemovalUserID != default(int)) { SQLFields += "U_REMOVE_U_ID, "; SQLValues += "@RemovalUserID, "; args.Add(new SQLArg("@RemovalUserID", RemovalUserID)); }
                if (StartDate != default(DateTime?)) { SQLFields += "U_START_DT, "; SQLValues += "@StartDate, "; args.Add(new SQLArg("@StartDate", StartDate)); }
                if (UserManagementAccess != default(bool)) { SQLFields += "U_MT_USERS, "; SQLValues += "@UserManagementAccess, "; args.Add(new SQLArg("@UserManagementAccess", UserManagementAccess ? 'y' : 'n')); }
                if (UserEnrolmentAccess != default(bool)) { SQLFields += "U_MT_ENROLMENTS, "; SQLValues += "@UserEnrolmentAccess, "; args.Add(new SQLArg("@UserEnrolmentAccess", UserEnrolmentAccess ? 'y' : 'n')); }
                if (ScheduledReportsAccess != default(bool)) { SQLFields += "U_MT_SCHEDULED_REPORTS, "; SQLValues += "@ScheduledReportsAccess, "; args.Add(new SQLArg("@ScheduledReportsAccess", ScheduledReportsAccess ? 'y' : 'n')); }
                if (ThirdPartyDatabaseUser != default(bool)) { SQLFields += "U_TPD_USER, "; SQLValues += "@ThirdPartyDatabaseUser, "; args.Add(new SQLArg("@ThirdPartyDatabaseUser", ThirdPartyDatabaseUser)); }

                if (SQLFields.Length > 0 && SQLValues.Length > 0)
                {
                    SQLFields = SQLFields.Substring(0, SQLFields.Length-2);
                    SQLValues = SQLValues.Substring(0, SQLValues.Length-2);

                    UserID = DAL.GetDataInt("INSERT INTO Users (" + SQLFields + ") OUTPUT Inserted.U_ID SELECT " + SQLValues, args);
                }
            }
            else
            {
                if (Title != default(string)) { SQLFields += "U_TITLE = @Title, "; args.Add(new SQLArg("@Title", Title)); }
                if (UserName != default(string)) { SQLFields += "U_USERNAME = @UserName, "; args.Add(new SQLArg("@UserName", UserName)); }
                if (PasswordHash != default(string)) { SQLFields += "U_PASSWORD = @PasswordHash, "; args.Add(new SQLArg("@PasswordHash", PasswordHash)); }
                if (FirstName != default(string)) { SQLFields += "U_NAME_FIRST = @FirstName, "; args.Add(new SQLArg("@FirstName", FirstName)); }
                if (LastName != default(string)) { SQLFields += "U_NAME_LAST = @LastName, "; args.Add(new SQLArg("@LastName", LastName)); }
                if (DistinguishingName != default(string)) { SQLFields += "U_DN = @DistinguishingName, "; args.Add(new SQLArg("@DistinguishingName", DistinguishingName)); }
                if (EMail != default(string)) { SQLFields += "U_EMAIL = @EMail, "; args.Add(new SQLArg("@EMail", EMail)); }
                if (Moderator != default(string)) { SQLFields += "U_MODERATOR = @Moderator, "; args.Add(new SQLArg("@Moderator", Moderator)); }
                if (isTutor != default(bool)) { SQLFields += "U_TUTOR = @isTutor, "; args.Add(new SQLArg("@isTutor", (isTutor ? "y" : "n"))); }
                if (isAdmin != default(bool)) { SQLFields += "U_ADMIN = @isAdmin, "; args.Add(new SQLArg("@isAdmin", (isAdmin ? "y" : "n"))); }
                if (CreateDate != default(DateTime?)) { SQLFields += "U_CREATE_DT = @CreateDate, "; args.Add(new SQLArg("@CreateDate", CreateDate)); }
                if (LastAccessDate != default(DateTime?)) { SQLFields += "U_LACCESS_DT = @LastAccessDate, "; args.Add(new SQLArg("@LastAccessDate", LastAccessDate)); }
                if (AudioOn != default(bool)) { SQLFields += "U_AUDIO_PREF = @AudioOn, "; args.Add(new SQLArg("@AudioOn", (AudioOn ? 1 : 0))); }
                if (Key != default(string)) { SQLFields += "U_KEY = @Key, "; args.Add(new SQLArg("@Key", Key)); }
                if (Status != default(string)) { SQLFields += "U_STATUS = @Status, "; args.Add(new SQLArg("@Status", Status)); }
                if (ModType != default(string)) { SQLFields += "U_MOD_TYPE = @ModType, "; args.Add(new SQLArg("@ModType", ModType)); }
                if (DiscAccess != default(int)) { SQLFields += "U_DISC_ACCESS = @DiscAccess, "; args.Add(new SQLArg("@DiscAccess", DiscAccess)); }
                if (UserFieldString1 != default(string)) { SQLFields += "U_FIELD_STR_1 = @UserFieldString1, "; args.Add(new SQLArg("@UserFieldString1", UserFieldString1)); }
                if (UserFieldString2 != default(string)) { SQLFields += "U_FIELD_STR_2 = @UserFieldString2, "; args.Add(new SQLArg("@UserFieldString2", UserFieldString2)); }
                if (UserFieldString3 != default(string)) { SQLFields += "U_FIELD_STR_3 = @UserFieldString3, "; args.Add(new SQLArg("@UserFieldString3", UserFieldString3)); }
                if (UserFieldString4 != default(string)) { SQLFields += "U_FIELD_STR_4 = @UserFieldString4, "; args.Add(new SQLArg("@UserFieldString4", UserFieldString4)); }
                if (UserFieldString5 != default(string)) { SQLFields += "U_FIELD_STR_5 = @UserFieldString5, "; args.Add(new SQLArg("@UserFieldString5", UserFieldString5)); }
                if (UserFieldDate1 != default(DateTime?)) { SQLFields += "U_FIELD_DT_1 = @UserFieldDate1, "; args.Add(new SQLArg("@UserFieldDate1", UserFieldDate1)); }
                if (UserFieldDate2 != default(DateTime?)) { SQLFields += "U_FIELD_DT_2 = @UserFieldDate2, "; args.Add(new SQLArg("@UserFieldDate2", UserFieldDate2)); }
                if (UserFieldDate3 != default(DateTime?)) { SQLFields += "U_FIELD_DT_3 = @UserFieldDate3, "; args.Add(new SQLArg("@UserFieldDate3", UserFieldDate3)); }
                if (UserFieldList1 != default(int)) { SQLFields += "U_FIELD_LIST_1 = @UserFieldList1, "; args.Add(new SQLArg("@UserFieldList1", UserFieldList1)); }
                if (UserFieldList2 != default(int)) { SQLFields += "U_FIELD_LIST_2 = @UserFieldList2, "; args.Add(new SQLArg("@UserFieldList2", UserFieldList2)); }
                if (UserFieldList3 != default(int)) { SQLFields += "U_FIELD_LIST_3 = @UserFieldList3, "; args.Add(new SQLArg("@UserFieldList3", UserFieldList3)); }
                if (PasswordReset != default(string)) { SQLFields += "U_PASSWORD_RESET = @PasswordReset, "; args.Add(new SQLArg("@PasswordReset", PasswordReset)); }
                if (PasswordResetDate != default(DateTime?)) { SQLFields += "U_PASS_RESET_TIME = @PasswordResetDate, "; args.Add(new SQLArg("@PasswordResetDate", PasswordResetDate)); }
                if (FailedLogins != default(int)) { SQLFields += "U_FAILEDLOGINS = @FailedLogins, "; args.Add(new SQLArg("@FailedLogins", FailedLogins)); }
                if (NONCE != default(string)) { SQLFields += "U_NONCE = @NONCE, "; args.Add(new SQLArg("@NONCE", NONCE)); }
                if (isPasswordHashed != default(bool)) { SQLFields += "U_PASS_HASHED = @isPasswordHashed, "; args.Add(new SQLArg("@isPasswordHashed", (isPasswordHashed ? 1 : 0))); }
                if (TempPassword != default(string)) { SQLFields += "U_P_TEMP = @TempPassword, "; args.Add(new SQLArg("@TempPassword", TempPassword)); }
                if (Salt != default(Guid)) { SQLFields += "U_SALT = @Salt, "; args.Add(new SQLArg("@Salt", Salt)); }
                if (LDAP_UniqueID != default(string)) { SQLFields += "U_LDAP_UNIQUEID = @LDAP_UniqueID, "; args.Add(new SQLArg("@LDAP_UniqueID", LDAP_UniqueID)); }
                if (LDAP_GUID != default(string)) { SQLFields += "U_LDAP_GUID = @LDAP_GUID, "; args.Add(new SQLArg("@LDAP_GUID", LDAP_GUID)); }
                if (Domain != default(string)) { SQLFields += "U_DOMAIN = @Domain, "; args.Add(new SQLArg("@Domain", Domain)); }
                if (DomainUsername != default(string)) { SQLFields += "U_DOMAIN_UNAME = @DomainUsername, "; args.Add(new SQLArg("@DomainUsername", DomainUsername)); }
                if (isActiveDirectoryUser != default(bool)) { SQLFields += "U_AD_USER = @isActiveDirectoryUser, "; args.Add(new SQLArg("@isActiveDirectoryUser", (isActiveDirectoryUser ? "y" : "n"))); }
                if (LanguageCode != default(string)) { SQLFields += "U_LANG_CODE = @LanguageCode, "; args.Add(new SQLArg("@LanguageCode", LanguageCode)); }
                if (NetBIOSAccount != default(string)) { SQLFields += "U_NETBIOS_ACCOUNT = @NetBIOSAccount, "; args.Add(new SQLArg("@NetBIOSAccount", NetBIOSAccount)); }
                if (GiftRegisterPermissionLevel != default(int)) { SQLFields += "U_GRPL_ACCESS_ID = @GiftRegisterPermissionLevel, "; args.Add(new SQLArg("@GiftRegisterPermissionLevel", GiftRegisterPermissionLevel)); }
                if (GiftRegisterRegionID != default(int)) { SQLFields += "U_GRR_ID = @GiftRegisterRegionID, "; args.Add(new SQLArg("@GiftRegisterRegionID", GiftRegisterRegionID)); }
                if (GiftRegisterEntityID != default(int)) { SQLFields += "U_GRE_ID = @GiftRegisterEntityID, "; args.Add(new SQLArg("@GiftRegisterEntityID", GiftRegisterEntityID)); }
                if (UserGUID != default(Guid)) { SQLFields += "U_GUID = @UserGUID, "; args.Add(new SQLArg("@UserGUID", UserGUID)); }
                if (Dashboard != default(bool)) { SQLFields += "U_DASHBOARD = @Dashboard, "; args.Add(new SQLArg("@Dashboard", Dashboard ? 'y' : 'n')); }
                if (LeavingDate != default(DateTime?)) { SQLFields += "U_LEAVE_DT = @LeavingDate, "; args.Add(new SQLArg("@LeavingDate", LeavingDate)); }
                if (RemovalDate != default(DateTime?)) { SQLFields += "U_REMOVE_DT = @RemovalDate, "; args.Add(new SQLArg("@RemovalDate", RemovalDate)); }
                if (RemovalUserID != default(int)) { SQLFields += "U_REMOVE_U_ID = @RemovalUserID, "; args.Add(new SQLArg("@RemovalUserID", RemovalUserID)); }
                if (StartDate != default(DateTime?)) { SQLFields += "U_START_DT = @StartDate, "; args.Add(new SQLArg("@StartDate", StartDate)); }
                if (UserManagementAccess != default(bool)) { SQLFields += "U_MT_USERS = @UserManagementAccess, "; args.Add(new SQLArg("@UserManagementAccess", UserManagementAccess ? 'y' : 'n')); }
                if (UserEnrolmentAccess != default(bool)) { SQLFields += "U_MT_ENROLMENTS = @UserEnrolmentAccess, "; args.Add(new SQLArg("@UserEnrolmentAccess", UserEnrolmentAccess ? 'y' : 'n')); }
                if (ScheduledReportsAccess != default(bool)) { SQLFields += "U_MT_SCHEDULED_REPORTS = @ScheduledReportsAccess, "; args.Add(new SQLArg("@ScheduledReportsAccess", ScheduledReportsAccess ? 'y' : 'n')); }
                if (ThirdPartyDatabaseUser != default(bool)) { SQLFields += "U_TPD_USER = @ThirdPartyDatabaseUser, "; args.Add(new SQLArg("@ThirdPartyDatabaseUser", ThirdPartyDatabaseUser)); }

                if (SQLFields.Length > 0)
                {
                    SQLFields = SQLFields.Substring(0, SQLFields.Length-2);

                    args.Add(new SQLArg("@ID", ID));
                    UserID = DAL.GetDataInt("UPDATE Users SET " + SQLFields + " OUTPUT Inserted.U_ID WHERE U_ID = @ID", args);
                }
            }

            return UserID;
        }
    }
}
