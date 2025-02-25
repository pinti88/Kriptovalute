using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class KriptoWallet
    {
        public class Kriptovaluta
        {
            [Key]
            public int wallet_id { get; set; }
            public string kripto_id { get; set; } = "";
          

        }
    }
}
