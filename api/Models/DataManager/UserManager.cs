using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class UserManager : IDataRepository<User>
    {
        private MyContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public UserManager(MyContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public User LogIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //     return null;

            // authentication successful
            return user;
        }
        public void Add(User user)
        {
            // validation
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                Console.WriteLine(">>>>>>>>>>>>>>>IsNullOrWhiteSpace");
                throw new Exception(">>>>>>>>>>>>>>>IsNullOrWhiteSpace");
            }

            if (_context.Users.Any(x => x.Email == user.Email))
            {
                Console.WriteLine("Email \"" + user.Email + "\" is already taken");
                throw new Exception("Email \"" + user.Email + "\" is already taken");
            }

            if (user.IdMetier == 0)
                user.IdMetier = null;
            // byte[] passwordHash, passwordSalt;
            // CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // user.PasswordHash = passwordHash;
            // user.PasswordSalt = passwordSalt;
            // user.ImageUrl = ImageService.Set(user.Email, user.ImageUrl, _hostingEnvironment.WebRootPath, "users");

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("null");
            }

        }

        public User Get(long id)
        {
            // user.ImageUrl = ImageService.Get(user.ImageUrl, _hostingEnvironment.WebRootPath);

            var user = _context.Users
               .Include(o => o.metier)
               .Include(o => o.location)
               .ThenInclude(o => o.quartier).ThenInclude(o => o.ville)
               .Where(o => o.Id == id)
               .FirstOrDefault();
               
            // for avoiding  Self referencing loop
            user.location.users = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Update(User userNew)
        {
            var userOld = _context.Users.Find(userNew.Id);

            if (userOld == null)
            {
                Console.WriteLine("User not found");
                throw new Exception("User not found");
            }

            // if (!string.IsNullOrWhiteSpace(userNew.Password))
            // {
            //     Console.WriteLine("Password IsNullOrWhiteSpace");
            //     throw new Exception("Password IsNullOrWhiteSpace");
            // }

            if (userNew.Email != userOld.Email)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.Email == userNew.Email))
                {
                    Console.WriteLine("Email " + userNew.Email + " is already taken");
                    throw new Exception("Password IsNullOrWhiteSpace");
                }
            }
            // ImageService.Delete(_hostingEnvironment.WebRootPath, userOld.ImageUrl);
            _context.Entry(userOld).State = EntityState.Detached;

            // userNew.ImageUrl = ImageService.Set(userNew.Email, userNew.ImageUrl, _hostingEnvironment.WebRootPath, "users");
            _context.Users.Update(userNew);
            _context.SaveChanges();
        }

        public string PostImage(IFormFile file)
        {
            try  
            {  
                // var file = Request.Form.Files[0];  
                string path = Path.Combine(_hostingEnvironment.WebRootPath, "Users");  
                if (!Directory.Exists(path))  
                {  
                    Directory.CreateDirectory(path);  
                }  
                if (file.Length > 0)  
                {  
                    string fullPath = Path.Combine(path, file.FileName);  
                    using (var stream = new FileStream(fullPath, FileMode.Create))  
                    {  
                        file.CopyTo(stream);  
                    }  
                }  
                return file.FileName;  
            }  
            catch (System.Exception ex)  
            {  
                return ex.Message;  
            }  
        }
    }
}