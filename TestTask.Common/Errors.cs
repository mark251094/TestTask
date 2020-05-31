using TestTask.Common.Models;

namespace TestTask.Common
{
    public static class Errors
    {
        public static ExpectedException USER_NOT_FOUND = new ExpectedException("User not found.");
        public static ExpectedException USER_NAME_ALREADY_TAKEN = new ExpectedException("This username is already taken.");
        public static ExpectedException EMAIL_ALREADY_TAKEN = new ExpectedException("This email is already taken.");
        public static ExpectedException NOT_SAVED = new ExpectedException("Changes not saved.");
    }
}
