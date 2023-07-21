namespace company_app.Exceptions
{
   public class InvalidIdException : Exception
   {
      // create constructor
      public InvalidIdException(int? id) : base($"id {id} not found in database")
      {

      }
   }
}
