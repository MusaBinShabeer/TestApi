using System.ComponentModel.DataAnnotations;

namespace MeteringManagementApi.Models.DBModels.DBTables
{
    public class tbl_user
    {
        [Key]
        public Guid user_id { get; set; }= Guid.NewGuid();
        public string user_name { get; set; } = string.Empty;
        public string user_first_name { get; set; } = string.Empty;
        public string user_last_name { get; set; } = string.Empty;
        public string user_email_address { get; set; } = string.Empty;
        public string user_phone_no { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public bool is_active { get; set; } = true;
        public Guid fk_user_type { get; set; } = Guid.Empty;
        public tbl_user_type? user_type { get; set; }

    }
}
