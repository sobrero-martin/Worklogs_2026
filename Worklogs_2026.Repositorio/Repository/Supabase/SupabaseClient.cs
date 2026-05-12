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
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImJzanhyYWFseHNwdnZqdWF5aGhnIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc3NTA1NDczNCwiZXhwIjoyMDkwNjMwNzM0fQ.yjNCpv2YetAQp0lLvhLb16HfKpVXwzD8hxCuTe59epg";

            client = new Client(url, key);
        }

        public Client GetClient() => client;
    }
}
