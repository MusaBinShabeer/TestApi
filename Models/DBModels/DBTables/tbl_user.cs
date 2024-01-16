using System.ComponentModel.DataAnnotations;

namespace TestApi.Models.DBModels.DBTables
{
    public class tbl_user
    {
        [Key]
        public Guid user_id { get; set; } = Guid.NewGuid();
        public string user_name { get; set; } = string.Empty;
        public string user_gender { get; set; } = string.Empty;
        public string user_phone_no { get; set; } = string.Empty;
        public string click { get; set; } = string.Empty;

    }
}
