using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FullWebProject.Services
{
    public class TextService : ITextService
    {
        int ITextService.ExtractSpecialCharacterFrom(char spec, string input)
        {
            int count = 0;
            foreach(char iterator in input)
            {
                if (iterator == spec)
                    count++; 
            }
            return count;
        }
    }
}
