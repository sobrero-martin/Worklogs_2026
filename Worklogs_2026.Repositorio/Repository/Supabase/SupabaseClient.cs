using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.Repositorio.Repository.Supabase
{
    public class SupabaseClient
    {
        private readonly Client client;

        public SupabaseClient()
        {
            var url = "https://bsjxraalxspvvjuayhhg.storage.supabase.co";
            var key = "";

            client = new Client(url, key);
        }

        public Client GetClient() => client;
    }
}
