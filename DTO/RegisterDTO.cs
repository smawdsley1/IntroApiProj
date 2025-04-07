namespace moontest1.DTO
{
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
/* What is a dto -> class to send data between another class 
 *      (front end -> backend) 
 * Why would I use it?
 *      The user model has sensitive/un-needed information (entraId, passwordHash, etc.) 
 *      We don't want everyone to be able to access that openly nor do we need it when registering.
 *      Therefore, we are only grabbing what we need of to register or login (username, password, role)
 */