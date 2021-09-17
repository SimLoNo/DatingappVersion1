using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatingappVersion1
{
    class AccountModel
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }

        public AccountModel(DataTable user)
        {
            foreach (DataRow row in user.Rows)
            {
                AccountId = Convert.ToInt32(row["accountId"]);
                Email = row["email"].ToString();
                Phone = Convert.ToInt32(row["phone"]);
                Password = row["password"].ToString();
                CreateDate = Convert.ToDateTime(row["createDate"]);
            }
        }
    }
}
