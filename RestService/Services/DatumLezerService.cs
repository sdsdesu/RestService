
namespace RestService.Services
{
    public class DatumLezerService : IDatumLezerService
    {

        public Task<string> sterrebeeldNaam(int dag, int maand)
        {

            string sterrebeeld = "";
            if ((maand == 1 && dag >= 20) || (maand == 2 && dag <= 18))
            {
                sterrebeeld = "Waterman";
            }
            else if ((maand == 2 && dag >= 19) || (maand == 3 && dag <= 20))
            {
                sterrebeeld = "Vissen";
            }
            else if ((maand == 3 && dag >= 21) || (maand == 4 && dag <= 19))
            {
                sterrebeeld = "Ram";
            }
            else if ((maand == 4 && dag >= 20) || (maand == 5 && dag <= 20))
            {
                sterrebeeld = "Stier";
            }
            else if ((maand == 5 && dag >= 21) || (maand == 6 && dag <= 20))
            {
                sterrebeeld = "Tweelingen";
            }
            else if ((maand == 6 && dag >= 21) || (maand == 7 && dag <= 22))
            {
                sterrebeeld = "Kreeft";
            }
            else if ((maand == 7 && dag >= 23) || (maand == 8 && dag <= 22))
            {
                sterrebeeld = "Leeuw";
            }
            else if ((maand == 8 && dag >= 23) || (maand == 9 && dag <= 22))
            {
                sterrebeeld = "Maagd";
            }
            else if ((maand == 9 && dag >= 23) || (maand == 10 && dag <= 22))
            {
                sterrebeeld = "Weegschaal";
            }
            else if ((maand == 10 && dag >= 23) || (maand == 11 && dag <= 21))
            {
                sterrebeeld = "Schorpioen";
            }
            else if ((maand == 11 && dag >= 22) || (maand == 12 && dag <= 21))
            {
                sterrebeeld = "Boogschutter";
            }
            else if ((maand == 12 && dag >= 22) || (maand == 1 && dag <= 19))
            {
                sterrebeeld = "Steenbok";
            }
            //return sterrebeeld;
            return Task.FromResult(sterrebeeld);


        }
    }

}
