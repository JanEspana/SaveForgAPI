using Microsoft.AspNetCore.Mvc;
using FrogGameAPI.Data;
using FrogGameAPI.Models;
using FrogGameAPI.Models.DTO;
using System.Security.Cryptography;
using System.Text;


namespace FrogGameAPI.Controllers
{
    [Route("api/[controller]")] // Indiquem que la ruta d'accés a aquest controlador és api/User (nom del controlador)
    [ApiController] // Indiquem que aquesta classe és un controlador d'API
    public class UserController : Controller
    {
        private readonly AppDbContext _context; // per realitzar la injecció de dependències de la base de dades
        private ResponseDTO _response; // Resposta a les peticions

        // Constructor, fem la injecció de dependències de la base de dades
        public UserController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDTO();
        }

        [HttpGet("GetUsers")] // Indiquem que aquest mètode respon a peticions GET, amb la ruta GetUsers
        public ResponseDTO GetUsers()
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef");
                byte[] IV = Encoding.UTF8.GetBytes("0123456789abcdef");
                IEnumerable<User> users = _context.Users.ToList(); // Obtenim tots els elements de la taula Users
                foreach (User user in users)
                {
                    user.Password = DecryptStringFromBytes(Convert.FromBase64String(user.Password), key, IV);
                }
                _response.Data = users; // Afegim els elements a la resposta
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetUserByUsername/{username}")] // Indiquem que aquest mètode respon a peticions GET, amb la ruta GetUserByUsername/username
        public ResponseDTO GetUserByUsername(string username)
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef");
                byte[] IV = Encoding.UTF8.GetBytes("0123456789abcdef");
                User user = _context.Users.FirstOrDefault(x => x.Username == username); // Obtenim l'element amb el username indicat
                user.Password = DecryptStringFromBytes(Convert.FromBase64String(user.Password), key, IV);
                _response.Data = user; // Afegim l'element a la resposta
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("PostUser")] // Indiquem que aquest mètode respon a peticions POST, amb la ruta PostUser
        public ResponseDTO PostUser([FromBody] User user)
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef");
                byte[] IV = Encoding.UTF8.GetBytes("0123456789abcdef");
                user.Password = Convert.ToBase64String(EncryptStringToBytes(user.Password, key, IV));
                _context.Users.Add(user); // Afegim l'element a la taula Items
                _context.SaveChanges(); // Guardem els canvis
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut("PutUser")] // Indiquem que aquest mètode respon a peticions PUT, amb la ruta PutUser
        public ResponseDTO PutUser([FromBody] User user)
        {
            try
            {
                _context.Users.Update(user); // Actualitzem l'element
                _context.SaveChanges(); // Guardem els canvis
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteUser/{name}")] // Indiquem que aquest mètode respon a peticions DELETE, amb la ruta DeleteUser/name
        public ResponseDTO DeleteUser(string name)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(x => x.Username == name); // Obtenim l'element amb el nom indicat
                _context.Users.Remove(user); // Eliminem l'element
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpGet("GetScoresByUser/{username}")]
        public ResponseDTO GetScoresByUser(string username)
        {
            try
            {
                IEnumerable<Score> scores;
                User user = _context.Users.FirstOrDefault(x => x.Username == username);
                IEnumerable<Score> allScores = _context.Scores.ToList();
                scores = allScores.Where(x => x.Username == username);
                _response.Data = scores;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] IV)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }
        static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] IV)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
