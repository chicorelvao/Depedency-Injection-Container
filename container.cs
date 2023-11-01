namespace container;

using System.Reflection;

public class DIContainer
{
    private static HashSet<Type> serviceClasses = new HashSet<Type>();

    public static void addService<T>()
    { 
        serviceClasses.Add(typeof(T));
    }
    

    
    private HashSet<Object> serviceInstances = new HashSet<Object>();

    public DIContainer()
    {
        foreach (Type serviceClass in serviceClasses) 
        {
            ConstructorInfo constructor = serviceClass.GetConstructor(Type.EmptyTypes);
            serviceInstances.Add(constructor.Invoke(null));
        }

        
        foreach (Object serviceInstance in serviceInstances)
        {
       
            foreach (PropertyInfo property in serviceInstance.GetType().GetProperties())
            {
                Type propertyType = property.PropertyType;

                foreach (Object matchPartner in serviceInstances)
                {
                    Type[] matchPartnerInterfaces = matchPartner.GetType().GetInterfaces();
                    foreach ( Type matchPartnerInterface in matchPartnerInterfaces)
                    {
                        if (propertyType == matchPartnerInterface)
                        {
                            property.SetValue(serviceInstance, matchPartner, null);
                        }
                    }
                }

            }

        }


    }


    public T getServiceInstance<T>()
    {
        foreach (Object serviceInstance in serviceInstances)
        {
            if (serviceInstance is T)
            {
                return (T) serviceInstance;
            }

            // Type[] serviceInstanceInterfaces = serviceInstance.GetType().GetInterfaces();
            // foreach ( Type serviceInstanceInterface in serviceInstanceInterfaces)
            // {
            //     if (serviceInstanceInterface == typeof(T))
            //     {
            //         return (T) serviceInstance;
            //     }
            // }

        }

        return default;
    }

    
}