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
        public TemplateDTO Template;

        public string DeleteTemplate(string templateName, int templateID)
        {
            string Query = $"DELETE FROM IVPJustin_{templateName} WHERE {templateName}_Id=" + templateID;
            
            using (cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                int Result = cmd.ExecuteNonQuery();
                conn.Close();

                if (Result == 0)
                {
                    return $"Delete of {templateName} Failed";
                }
                else
                {
                    return $"Delete of {templateName} was a succes";
                }
            };
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
                    if (templateName == "Location")
                    {
                        Template = CreateLocationTemplate(reader, "stop");
                        Templates.Add(Template);
                    }
                }
            }
            conn.Close();
            return Templates;
        }

        public TemplateDTO GetATemplateById(int templateId, string templateName)
        {
            string Query = $"SELECT * FROM IVPJustin_{templateName} WHERE {templateName}_Id=" + templateId;

            conn.Open();
            cmd = new SqlCommand(Query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (templateName == "Location")
                {
                    Template = CreateLocationTemplate(reader, "start");
                }
            }
            conn.Close();
            return Template;
        }

        private static TemplateDTO CreateLocationTemplate(SqlDataReader reader, string readerCheck)
        {
            if (readerCheck == "start")
            {
                if (reader.Read())
                {
                    return CreateLocationDTO(reader);
                }
                else
                {
                    return new TemplateDTO();
                }
            }
            else
            {
                return CreateLocationDTO(reader);
            }
        }

        private static TemplateDTO CreateLocationDTO(SqlDataReader reader)
        {
            return new TemplateDTO
            {
                LocationId = reader.GetInt32(0),
                Name = reader.GetString(1),
                Title = reader.GetString(2),
                Story = reader.GetString(3),
                AreaId = reader.GetInt32(4),
                FotoUrl = reader.GetString(5)
            };
        }

        public string UpdateTemplate(int templateId, TemplateDTO templateDTO, string templateName)
        {
            return ChooseTemplateAction(templateName, templateDTO, "Update", templateId);
        }

        public string CreateTemplate(string templateName, TemplateDTO templateDTO)
        {
            return ChooseTemplateAction(templateName, templateDTO, "Create", 0);
        }

        public string ChooseTemplateAction(string templateName, TemplateDTO templateDTO, string actionName, int templateId)
        {
            if (templateName == "Location")
            {
                return ChooseAction(templateName, templateDTO, actionName, templateId);
            }
            else if (templateName == "NPC")
            {
                return ChooseAction(templateName, templateDTO, actionName, templateId);
            }
            else if (templateName == "Monster")
            {
                return ChooseAction(templateName, templateDTO, actionName, templateId);
            }
            else if (templateName == "Item")
            {
                return ChooseAction(templateName, templateDTO, actionName, templateId);
            }
            else if (templateName == "Shop")
            {
                return ChooseAction(templateName, templateDTO, actionName, templateId);
            }
            else if (templateName == "area")
            {
                return ChooseAction(templateName, templateDTO, actionName, templateId);
            }
            else
            {
                return "TemplateName has not been reconigzed";
            }
        }

        public string ChooseAction(string templateName, TemplateDTO templateDTO, string actionName, int templateId)
        {
            TemplateStorage = templateDTO;
            var classType = GetType();
            string methodName =  actionName + templateName;
            if (actionName == "Create")
            {
                return InvokerClass.InvokeStringToMethod(classType.ToString(), methodName, templateName, templateDTO, 0);
            }
            else if(actionName == "Update")
            {
                return InvokerClass.InvokeStringToMethod(classType.ToString(), methodName, templateName, templateDTO, templateId);
            }
            else
            {
                return "Action not reconigezed";
            }
        }

        public string UpdateLocation(string templateName, TemplateDTO templateDTO, int templateId)
        {
            string Query = $"Update IVPJustin_{templateName} " +
                $"SET Name=@Name, Title=@Title, Story=@Story, area_Id=@area_Id, Foto_url=@Foto_url WHERE Location_id={templateId}";

            using(SqlCommand cmd = new SqlCommand(Query, conn))
            {
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.VarChar).Value = templateDTO.Name;
                cmd.Parameters.Add("@Title", System.Data.SqlDbType.VarChar).Value = templateDTO.Title;
                cmd.Parameters.Add("@Story", System.Data.SqlDbType.VarChar).Value = templateDTO.Story;
                cmd.Parameters.Add("@area_Id", System.Data.SqlDbType.Int).Value = templateDTO.AreaId;
                cmd.Parameters.Add("@Foto_url", System.Data.SqlDbType.VarChar).Value = templateDTO.FotoUrl;

                conn.Open();
                //System.Data.SqlClient.SqlException : Incorrect syntax near '('.
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                if (result == 0)
                {
                    return "Update of Location failed";
                }
                else
                {
                    return "Update succesfull";
                }

            }
        }

        public string CreateMonster(string templateName, TemplateDTO templateDTO, int templateId)
        {
            throw new NotImplementedException();
        }

        public string CreateItem(string templateName, TemplateDTO templateDTO, int templateId)
        {
            throw new NotImplementedException();
        }

        public string CreateArea(string templateName, TemplateDTO templateDTO, int templateId)
        {
            throw new NotImplementedException();
        }

        public string CreateShop(string templateName, TemplateDTO templateDTO, int templateId)
        {
            throw new NotImplementedException();
        }

        public string CreateNPC(string templateName, TemplateDTO templateDTO, int templateId)
        {
            throw new NotImplementedException();
        }

        public string CreateLocation(string templateName, TemplateDTO templateDTO, int templateId)
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
