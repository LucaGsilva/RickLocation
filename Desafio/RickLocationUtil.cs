using Desafio.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio
{
    public static class RickLocationUtil
    {

        public static async Task<ApplicationResult> CallService<T>(String sucess, String error, Func<Task<T>> function)
        {
            var result = new ApplicationResult();

            try
            {
                result.Data = await function();
                result.Messages.Add(sucess);
            }
            catch (RickLocationException e)
            {

                result.Code = 500;
                result.Messages.Add(e.Message);
            }
            catch (ArgumentException e)
            {

                result.Code = 500;
                result.Messages.Add(e.Message);
            }
            catch (Exception e)
            {

                result.Code = 500;
                result.Messages.Add(error);
            }

            return result;
        }
    }
}
