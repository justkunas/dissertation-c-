using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dissertation
{

    public class LuceneCommand
    {

        Commands cmd;
        Query query;
        string ip;
        int port;

        public LuceneCommand(Commands cmd, string ip, int port)
        {
            if (cmd == Commands.QUERY)
            {
                throw new ParameterNotFoundException();
            }
            Command = cmd;
            IP = ip;
            Port = port;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public LuceneCommand(Commands cmd, Query query, string ip, int port)
        {
            if(cmd == Commands.QUERY && query == null)
            {
                throw new ParameterNotFoundException();
            }
            Command = cmd;
            Query = query;
            IP = ip;
            Port = port;
        }

        public Commands Command
        {
            get
            {
                return cmd;
            }
            set
            {
                cmd = value;
            }
        }

        public Query Query
        {
            get
            {
                return query;
            }
            set
            {
                query = value;
            }
        }

        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public enum Commands
        {
            QUERY,
            NEXT,
            PREVIOUS,
            LOAD
        }
    }
}
