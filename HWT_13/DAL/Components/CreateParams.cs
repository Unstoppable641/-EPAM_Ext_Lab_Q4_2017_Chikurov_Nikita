namespace DAL.Components
{
    using System;
    using System.Data.Common;
    
    public static class CreateParams
    {
        internal static void AddParameterWithValue(this DbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
    }
}
