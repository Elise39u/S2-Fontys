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
        public TemplateDTO TemplateStorage;

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

        public TemplateDTO GetATemplateById(int templateId, string templateName)
        {
            throw new NotImplementedException();
        }

        public string UpdateTemplate(TemplateDTO templateDTO, string templateName)
        {
            throw new NotImplementedException();
        }

        public string CreateTemplate(string templateName, TemplateDTO templateDTO)
        {
            return ChooseTemplateAction(templateName, templateDTO, "Create");
        }

        private string ChooseTemplateAction(string templateName, TemplateDTO templateDTO, string actionName)
        {
            if (templateName == "Location")
            {
                return ChooseAction(templateName, templateDTO, actionName);
                // return CreateLocation()
            }
            else if (templateName == "NPC")
            {
                return ChooseAction(templateName, templateDTO, actionName);
                //return CreateNpc(templateName, templateDTO);
            }
            else if (templateName == "Monster")
            {
                return ChooseAction(templateName, templateDTO, actionName);
                // return CreateMonster(templateName, templateDTO);
            }
            else if (templateName == "Item")
            {
                return ChooseAction(templateName, templateDTO, actionName);
                // return CreateItem(templateName, templateDTO);
            }
            else if (templateName == "Shop")
            {
                return ChooseAction(templateName, templateDTO, actionName);
                //return CreateShop(templateName, templateDTO);
            }
            else if (templateName == "area")
            {
                return ChooseAction(templateName, templateDTO, actionName);
                //return CreateArea(templateName, templateDTO);
            }
            else
            {
                return "TemplateName is not been reconigzed";
            }
        }

        private string ChooseAction(string templateName, TemplateDTO templateDTO, string actionName)
        {
            TemplateStorage = templateDTO;
            if (actionName == "Create")
            {
                return StringExtensions.InvokeStringToMethod("TemplateDAL", actionName + templateName, templateName);
                //return methodName(templateName, templateDTO);
            }
            else if(actionName == "Update")
            {
                return StringExtensions.InvokeStringToMethod("TemplateDAL", actionName + templateName, templateName);
            }
            else
            {
                return "Action not reconigezed";
            }
        }

        private string UpdateLocation(string templateName, TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }

        private string CreateMonster(string templateName, TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }

        private string CreateItem(string templateName, TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }

        private string CreateArea(string templateName, TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }

        private string CreateShop(string templateName, TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }

        private string CreateNpc(string templateName, TemplateDTO templateDTO)
        {
            throw new NotImplementedException();
        }

        private string CreateLocation(string templateName, TemplateDTO templateDTO)
        {
            string Query = $"INSERT INTO IVPJustin_{templateName}(Name, Title, Story, area_Id, Foto_url) " +
                $"VALUES(@Name, @Title, @Story, @area_Id, @Foto_url)";

            using(SqlCommand cmd = new SqlCommand(Query, conn))
            {
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = templateDTO.Name;
                cmd.Parameters.Add("@Title", System.Data.SqlDbType.VarChar).Value = templateDTO.Title;
                cmd.Parameters.Add("@Story", System.Data.SqlDbType.VarChar).Value = templateDTO.Story;
                cmd.Parameters.Add("@area_Id", System.Data.SqlDbType.Int).Value = templateDTO.AreaId;
                cmd.Parameters.Add("@Foto_url", System.Data.SqlDbType.VarChar).Value = templateDTO.FotoUrl;

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                if(result == 0)
                {
                    return "Insert of Location failed";
                }
                else
                {
                    return "Insert succesfull";
                }
            }
        }
    }
}
