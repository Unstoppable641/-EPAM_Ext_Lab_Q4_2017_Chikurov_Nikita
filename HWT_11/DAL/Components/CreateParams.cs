namespace DAL.Components
{
    using System.Data.Common;
    
    public static class CreateParams
    {
        public static void CreateParameterWithValue(this DbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
    }
}
