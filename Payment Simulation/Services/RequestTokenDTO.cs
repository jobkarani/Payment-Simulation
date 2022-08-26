using System.Net.Http;
using System.Threading.Tasks;

namespace Payment_Simulation.Services
{
    public class RequestTokenDTO
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}
