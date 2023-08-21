using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models.DBModels.DBTables
{
    public class tbl_user_type
    {
        [Key]
        public Guid type_id { get; set; } = Guid.NewGuid();
        public string type_name { get; set; } = string.Empty;
        public bool is_active { get; set; } = true;
        public IEnumerable<tbl_user> users { get; set; } = default!;
    }
}
