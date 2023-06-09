using System;

namespace HomeWeatherWeb.Server.Mappers
{
    public class MainDtoMapper<T, U> : IMainDtoMapper<T, U> where T : class, new() where U : class, new()
    {
        public T MapDtoToObject(U obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var objectToEntity = new T();

            var entityAssemblyObj = typeof(T).AssemblyQualifiedName;

            Type entityType = Type.GetType(entityAssemblyObj);

            var dtoProps = typeof(U).GetProperties();

            var entityPropList = entityType.GetProperties();

            foreach (var property in entityPropList)
            {
                for (int i = 0; i < dtoProps.Length; i++)
                {
                    if (property.Name.ToLower().Equals(dtoProps[i].Name.ToLower())
                            && PropertiesAreSame(property, dtoProps[i]))
                    {
                        var val = dtoProps[i].GetValue(obj);
                        property.SetValue(objectToEntity, val, null);
                    }
                }
            }
            return objectToEntity;
        }

        /// <summary>
        /// Create a Data Transfer object based on entity.
        /// </summary>
        /// <param name="obj">Entity to transform into DTO.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public U MapObjectToDto(T obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var objectToConvert = new U();

            var dtoObject = typeof(U).AssemblyQualifiedName;

            Type type = Type.GetType(dtoObject);  // get Type of DTO object

            Activator.CreateInstance(type); // instatiate DTO object
            
            var props = typeof(T).GetProperties();  // properties of entity object
            var dtoProp = typeof(U);

            var list = dtoProp.GetProperties();     // get properties of DTO class

            foreach (var property in list)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    if (EqualPropertiesByName(property.Name, props[i].Name) && PropertiesAreSame(property, props[i]))
                    {
                        var val = props[i].GetValue(obj);
                        property.SetValue(objectToConvert, val, null);
                    }
                }
            }

            return objectToConvert;
        }

        private bool PropertiesAreSame(object prop1, object prop2)
        {
            var areSame = false;

            if (prop1.GetType().Equals(prop2.GetType()))
            {
                areSame = true;
            }

            return areSame;
        }

        private bool EqualPropertiesByName(string name1, string name2)
        {
            return name1.ToLower().Equals(name2.ToLower());
        }
    }
}
