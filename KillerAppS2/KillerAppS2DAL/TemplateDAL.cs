using KillerAppS2DTO;
using KillerAppS2Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace KillerAppS2DAL
{
    public class TemplateDAL : ITemplateLogic<TemplateDTO>, ITemplateContainer<TemplateDTO>
    {
        static string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi403879;Persist Security Info=True;User ID=dbi403879;Password=BigFish";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd;
        public List<TemplateDTO> Templates = new List<TemplateDTO>();

        public TemplateDTO DeleteTemplate()
        {
            throw new NotImplementedException();
        }

        public List<TemplateDTO> GetALLTemplatesFromDB(string templateName)
        {
            string Query = $"SELECT * FROM IVPJustin_{templateName}";

            conn.Open();
            cmd = new SqlCommand(Query, conn);
            using(SqlDataReader reader =  cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    TemplateDTO template = new TemplateDTO
                    {
                        LocationId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Title = reader.GetString(2),
                        Story = reader.GetString(3),
                        AreaId = reader.GetInt32(4),
                        FotoUrl = reader.GetString(5)
                    };

                    Templates.Add(template);
                }
            }
            conn.Close();
            return Templates;
        }

        public TemplateDTO GetATemplateById()
        {
            throw new NotImplementedException();
        }

        public TemplateDTO UpdateTemplate(TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
