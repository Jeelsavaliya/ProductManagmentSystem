namespace ProductManagmentSystem.Authentication
{
    public static class CommonVariable
    {
        private static IHttpContextAccessor _HttpContextAccessor;
        static CommonVariable()
        {
            _HttpContextAccessor = new HttpContextAccessor();
        }
        public static int? UserID()
        {
            int? UserId = null;
            if (_HttpContextAccessor.HttpContext.Session.GetString("UserID") != null)
            {
                UserId = Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserID"));
            }
            return UserId;

            //UserID = Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserId"));
        }

        public static string? Email()
        {
            string? Email = null;
            if (_HttpContextAccessor.HttpContext.Session.GetString("UserSession") != null)
            {
                Email = _HttpContextAccessor.HttpContext.Session.GetString("UserSession").ToString();
            }
            return Email;
            //return _HttpContextAccessor.HttpContext.Session.GetString("Email");
        }

        public static string? FirstName()
        {
            string? FirstName = null;

            if (_HttpContextAccessor.HttpContext.Session.GetString("FirstName") != null)
            {
                FirstName = _HttpContextAccessor.HttpContext.Session.GetString("FirstName").ToString();
            }
            return FirstName;


            //return _HttpContextAccessor.HttpContext.Session.GetString("FirstName");
        }
    }
}
