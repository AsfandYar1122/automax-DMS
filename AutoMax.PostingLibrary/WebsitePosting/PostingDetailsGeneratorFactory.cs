using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMax.Models;
using AutoMax.Models.Entities;

namespace AutoMax.PostingLibrary.WebsitePosting
{
    public class PostingDetailsGeneratorFactory
    {
        private static PostingDetailsGeneratorFactory instance;

        private PostingDetailsGeneratorFactory() { }

        public static PostingDetailsGeneratorFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PostingDetailsGeneratorFactory();
                }
                return instance;
            }
        }
        public PostingDetailsGenerator GetPostingDetailsGenerator(string language)
        {
            if (language == "English")
                return new EnglishGenerator();
            else if (language == "Arabic")
                return new ArabicGenerator();
            throw new Exception("Generator not found");
        }
    }
}