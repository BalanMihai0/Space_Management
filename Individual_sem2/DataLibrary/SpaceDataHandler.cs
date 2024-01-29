using SpaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserLibrary;

namespace DataLibrary
{
    public class SpaceDataHandler : ISpaceDataInterface
    {
        void ISpaceDataInterface.AddSpaceObject(SpaceObject spaceObject) 
        {
            try
            {
                if( DoesObjectAlreadyExist(spaceObject.Name)) { throw new Exception("Object already exists"); }

                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //inserting the object
                        string query1 = @"INSERT INTO S2_Individual_SpaceObject 
                        (Name, Size, Mass, PositionX, PositionY, PositionZ,VelocityX, VelocityY, VelocityZ, OrientationX, OrientationY, OrientationZ) 
                        VALUES (@Name, @Size, @Mass, @PositionX, @PositionY, @PositionZ, @VelocityX, @VelocityY, @VelocityZ, @OrientationX, @OrientationY, @OrientationZ)";

                        using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                        {
                            command1.Parameters.AddWithValue("@Name", spaceObject.Name);
                            command1.Parameters.AddWithValue("@Size", spaceObject.Size);
                            command1.Parameters.AddWithValue("@Mass", spaceObject.Mass);
                            command1.Parameters.AddWithValue("@PositionX", spaceObject.Position.X);
                            command1.Parameters.AddWithValue("@PositionY", spaceObject.Position.Y);
                            command1.Parameters.AddWithValue("@PositionZ", spaceObject.Position.Z);
                            command1.Parameters.AddWithValue("@VelocityX", spaceObject.Velocity.X);
                            command1.Parameters.AddWithValue("@VelocityY", spaceObject.Velocity.Y);
                            command1.Parameters.AddWithValue("@VelocityZ", spaceObject.Velocity.Z);
                            command1.Parameters.AddWithValue("@OrientationX", spaceObject.Orientation.X);
                            command1.Parameters.AddWithValue("@OrientationY", spaceObject.Orientation.Y);
                            command1.Parameters.AddWithValue("@OrientationZ", spaceObject.Orientation.Z);

                            int rowsAffected = command1.ExecuteNonQuery();
                            Console.WriteLine($"Inserted {rowsAffected} row(s)");
                        }

                        string query2 = @"INSERT INTO S2_Individual_OrbitalData 
                        (ObjectName, OrbitType, SemiMajorAxis, Inclination, LongitudeOfAscNode, TrueAnomaly) 
                        VALUES (@ObjectName, @OrbitType, @SemiMajorAxis, @Inclination, @LongitudeOfAscNode, @TrueAnomaly)";

                        // inserting orbital data using parameterized query
                        using (SqlCommand command2 = new SqlCommand(query2, conn, transaction))
                        {
                            command2.Parameters.AddWithValue("@ObjectName", spaceObject.Name);
                            command2.Parameters.AddWithValue("@OrbitType", spaceObject.OrbitalData.OrbitType.ToString());
                            command2.Parameters.AddWithValue("@SemiMajorAxis", spaceObject.OrbitalData.SemiMajorAxis);
                            command2.Parameters.AddWithValue("@Inclination", spaceObject.OrbitalData.Inclination);
                            command2.Parameters.AddWithValue("@LongitudeOfAscNode", spaceObject.OrbitalData.LongitudeOfAscendingNode);
                            command2.Parameters.AddWithValue("@TrueAnomaly", spaceObject.OrbitalData.TrueAnomaly);

                            int rowsAffected = command2.ExecuteNonQuery();
                            Console.WriteLine($"Inserted {rowsAffected} row(s)");
                        }


                        //inserting in foreign key tables
                        if (spaceObject is Satellite satellite)
                        {
                            //general data
                            string query3 = @"INSERT INTO S2_Individual_SpaceObject_Satellite 
                            (Name, Model, Manufacturer, Objective) 
                            VALUES (@Name, @Model, @Manufacturer, @Objective)";

                            // inserting satellite data using parameterized query
                            using (SqlCommand command3 = new SqlCommand(query3, conn, transaction))
                            {
                                command3.Parameters.AddWithValue("@Name", spaceObject.Name);
                                command3.Parameters.AddWithValue("@Model", ((Satellite)spaceObject).Model);
                                command3.Parameters.AddWithValue("@Manufacturer", ((Satellite)spaceObject).Manufacturer);
                                command3.Parameters.AddWithValue("@Objective", ((Satellite)spaceObject).Objective);

                                int rowsAffected = command3.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }


                            //launch data
                            string query4 = @"INSERT INTO S2_Individual_Launch 
                            (ObjectName, LaunchDate, LaunchPositionX, LaunchPositionY, LaunchPositionZ, LandingDate ) 
                            VALUES (@ObjectName, @LaunchDate, @LaunchPositionX, @LaunchPositionY, @LaunchPositionZ, @LandingDate)";

                            using (SqlCommand command4 = new SqlCommand(query4, conn, transaction))
                            {
                                command4.Parameters.AddWithValue("@ObjectName", spaceObject.Name);
                                command4.Parameters.AddWithValue("@LaunchDate", ((Satellite)spaceObject).LaunchData.LaunchDate.ToString("yyyy-MM-dd HH:mm:ss") ?? "NULL");
                                command4.Parameters.AddWithValue("@LaunchPositionX", ((Satellite)spaceObject).LaunchData.LaunchLocation.X);
                                command4.Parameters.AddWithValue("@LaunchPositionY", ((Satellite)spaceObject).LaunchData.LaunchLocation.Y);
                                command4.Parameters.AddWithValue("@LaunchPositionZ", ((Satellite)spaceObject).LaunchData.LaunchLocation.Z);
                                command4.Parameters.AddWithValue("@LandingDate", DateTime.Parse(((Satellite)spaceObject).LaunchData.LaunchDate.ToString("yyyy-MM-dd HH:mm:ss") ?? "NULL"));

                                int rowsAffected = command4.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }


                            //telemetry data
                            string query5 = @"INSERT INTO S2_Individual_Satellite_TelemetryData 
                            (ObjectName, Temperature, BatteryLevel, BoardComputerHealth, HullIntegrity ) 
                            VALUES (@ObjectName, @Temperature, @BatteryLevel, @BoardComputerHealth, @HullIntegrity)";

                            // inserting telemetry data using parameterized query
                            using (SqlCommand command5 = new SqlCommand(query5, conn, transaction))
                            {
                                command5.Parameters.AddWithValue("@ObjectName", spaceObject.Name);
                                command5.Parameters.AddWithValue("@Temperature", ((Satellite)spaceObject).TelemetryData.Temperature);
                                command5.Parameters.AddWithValue("@BatteryLevel", ((Satellite)spaceObject).TelemetryData.BatteryLevel);
                                command5.Parameters.AddWithValue("@BoardComputerHealth", ((Satellite)spaceObject).TelemetryData.BoardComputerHealth);
                                command5.Parameters.AddWithValue("@HullIntegrity", ((Satellite)spaceObject).TelemetryData.HullIntegrity);

                                int rowsAffected = command5.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }


                        }
                        else if (spaceObject is Station station)
                        {
                            //insert the station
                            string query3 = @"INSERT INTO S2_Individual_SpaceObject_Station 
                            (Name, Model, ResearchType) 
                            VALUES (@Name, @Model, @ResearchType)";

                            using (SqlCommand command3 = new SqlCommand(query3, conn, transaction))
                            {
                                command3.Parameters.AddWithValue("@Name", spaceObject.Name);
                                command3.Parameters.AddWithValue("@Model", ((Station)spaceObject).Model);
                                command3.Parameters.AddWithValue("@ResearchType", ((Station)spaceObject).ResearchType.ToString());

                                int rowsAffected = command3.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }


                            //insert the telemetrydata
                            string query5 = @"INSERT INTO S2_Individual_Station_TelemetryData 
                            (ObjectName, Temperature, BatteryLevel, BoardComputerHealth, HullIntegrity ) 
                            VALUES (@ObjectName, @Temperature, @BatteryLevel, @BoardComputerHealth, @HullIntegrity)";

                            // inserting the telemetry data
                            using (SqlCommand command5 = new SqlCommand(query5, conn, transaction))
                            {
                                command5.Parameters.AddWithValue("@ObjectName", spaceObject.Name);
                                command5.Parameters.AddWithValue("@Temperature", ((Station)spaceObject).TelemetryData.Temperature);
                                command5.Parameters.AddWithValue("@BatteryLevel", ((Station)spaceObject).TelemetryData.BatteryLevel);
                                command5.Parameters.AddWithValue("@BoardComputerHealth", ((Station)spaceObject).TelemetryData.BoardComputerHealth);
                                command5.Parameters.AddWithValue("@HullIntegrity", ((Station)spaceObject).TelemetryData.HullIntegrity);

                                int rowsAffected = command5.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }
                        }
                        else if (spaceObject is Debris debris)
                        {
                            //insert the debris
                            string query3 = @"INSERT INTO S2_Individual_SpaceObject_Debris 
                            (Name, DangerRadius) 
                            VALUES (@Name, @DangerRadius)";
                            // insert the debris
                            using (SqlCommand command3 = new SqlCommand(query3, conn, transaction))
                            {
                                command3.Parameters.AddWithValue("@Name", spaceObject.Name);
                                command3.Parameters.AddWithValue("@DangerRadius", ((Debris)spaceObject).DangerRadius);

                                int rowsAffected = command3.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }

                        }
                        else throw new Exception("how");


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If any exceptions were thrown, roll back the transaction
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        bool DoesObjectAlreadyExist(string name)
        {
            using (SqlConnection connection = new SqlConnection(Database.Connection))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM S2_Individual_SpaceObject WHERE Name = @Name", connection);
                command.Parameters.AddWithValue("@Name", name);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        List<SpaceObject> ISpaceDataInterface.GetAllSatellites()
        {
            List<SpaceObject> satellites = new List<SpaceObject>();

            using (SqlConnection conn = new SqlConnection(Database.Connection))
            {
                conn.Open();

                string query = @"SELECT * FROM S2_Individual_SpaceObject 
                        INNER JOIN S2_Individual_OrbitalData ON S2_Individual_SpaceObject.Name = S2_Individual_OrbitalData.ObjectName 
                        LEFT JOIN S2_Individual_SpaceObject_Satellite ON S2_Individual_SpaceObject.Name = S2_Individual_SpaceObject_Satellite.Name 
                        LEFT JOIN S2_Individual_Launch ON S2_Individual_SpaceObject.Name = S2_Individual_Launch.ObjectName 
                        LEFT JOIN S2_Individual_Satellite_TelemetryData ON S2_Individual_SpaceObject.Name = S2_Individual_Satellite_TelemetryData.ObjectName
                        WHERE S2_Individual_SpaceObject_Satellite.Name IS NOT NULL";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //getting base attributes
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            double size = reader.GetDouble(reader.GetOrdinal("Size"));
                            double mass = reader.GetDouble(reader.GetOrdinal("Mass"));
                            Vector3 position = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("PositionX")),
                                (float)reader.GetDouble(reader.GetOrdinal("PositionY")),
                                (float)reader.GetDouble(reader.GetOrdinal("PositionZ"))
                            );
                            Vector3 velocity = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityX")),
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityY")),
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityZ"))
                            );
                            Vector3 orientation = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationX")),
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationY")),
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationZ"))
                            );
                                
                            //getting orbital data
                            string orbitType = reader.GetString(reader.GetOrdinal("OrbitType"));
                            double semiMajorAxis = reader.GetDouble(reader.GetOrdinal("SemiMajorAxis"));
                            double inclination = reader.GetDouble(reader.GetOrdinal("Inclination"));
                            double longitudeOfAscendingNode = reader.GetDouble(reader.GetOrdinal("LongitudeOfAscNode"));
                            double trueAnomaly = reader.GetDouble(reader.GetOrdinal("TrueAnomaly"));
                            OrbitType temptype;
                            Enum.TryParse<OrbitType>(orbitType, out temptype); // converting db string back to enum
                            OrbitalData orbitalData = new OrbitalData(semiMajorAxis, inclination, longitudeOfAscendingNode, trueAnomaly, temptype);

                            //getting satellite specific data
                            string model = reader.GetString(reader.GetOrdinal("Model"));
                            string manufacturer = reader.GetString(reader.GetOrdinal("Manufacturer"));
                            string objective = reader.GetString(reader.GetOrdinal("Objective"));
                                
                            //getting launch data
                            DateTime launchDate = reader.GetDateTime(reader.GetOrdinal("LaunchDate"));
                            Vector3 launchPosition = new Vector3((float)Convert.ToDouble(reader.GetDouble(reader.GetOrdinal("LaunchPositionX"))),
                                                        (float)Convert.ToDouble(reader.GetDouble(reader.GetOrdinal("LaunchPositionY"))),
                                                        (float)Convert.ToDouble(reader.GetDouble(reader.GetOrdinal("LaunchPositionZ"))));
                            DateTime landingDate = reader.GetDateTime(reader.GetOrdinal("LandingDate"));
                            Launch launch = new Launch(launchDate, launchPosition, landingDate);
                                
                            //getting telemetry data
                            double battery = reader.GetDouble(reader.GetOrdinal("BatteryLevel"));
                            double temperature = reader.GetDouble(reader.GetOrdinal("Temperature"));
                            double hullIntegrity = reader.GetDouble(reader.GetOrdinal("HullIntegrity"));
                            double boardComputerHealth = reader.GetDouble(reader.GetOrdinal("BoardComputerHealth"));
                                
                            //constructing satellite with all info
                            Satellite satellite = new Satellite(model, objective, new Launch(launchDate, launchPosition, landingDate), manufacturer,
                                name, size, mass, position, velocity, orientation, temptype, battery, temperature, hullIntegrity, boardComputerHealth);
                            //add satellite to list
                            satellites.Add(satellite);

                            }
                            
                    }
                }
            }
        return satellites;
        }

        List<SpaceObject> ISpaceDataInterface.GetAllStations()
        {
            List<SpaceObject> stations = new List<SpaceObject>();

            using (SqlConnection conn = new SqlConnection(Database.Connection))
            {
                conn.Open();

                string query = @"SELECT * FROM S2_Individual_SpaceObject 
                        INNER JOIN S2_Individual_OrbitalData ON S2_Individual_SpaceObject.Name = S2_Individual_OrbitalData.ObjectName 
                        LEFT JOIN S2_Individual_SpaceObject_Station ON S2_Individual_SpaceObject.Name = S2_Individual_SpaceObject_Station.Name 
                        LEFT JOIN S2_Individual_Station_TelemetryData ON S2_Individual_SpaceObject.Name = S2_Individual_Station_TelemetryData.ObjectName
                         WHERE S2_Individual_SpaceObject_Station.Name IS NOT NULL";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //getting base attributes
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            double size = reader.GetDouble(reader.GetOrdinal("Size"));
                            double mass = reader.GetDouble(reader.GetOrdinal("Mass"));
                            Vector3 position = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("PositionX")),
                                (float)reader.GetDouble(reader.GetOrdinal("PositionY")),
                                (float)reader.GetDouble(reader.GetOrdinal("PositionZ"))
                            );
                            Vector3 velocity = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityX")),
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityY")),
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityZ"))
                            );
                            Vector3 orientation = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationX")),
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationY")),
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationZ"))
                            );

                            //getting orbital data
                            string orbitType = reader.GetString(reader.GetOrdinal("OrbitType"));
                            double semiMajorAxis = reader.GetDouble(reader.GetOrdinal("SemiMajorAxis"));
                            double inclination = reader.GetDouble(reader.GetOrdinal("Inclination"));
                            double longitudeOfAscendingNode = reader.GetDouble(reader.GetOrdinal("LongitudeOfAscNode"));
                            double trueAnomaly = reader.GetDouble(reader.GetOrdinal("TrueAnomaly"));
                            OrbitType temptype;
                            Enum.TryParse<OrbitType>(orbitType, out temptype); // converting db string back to enum
                            OrbitalData orbitalData = new OrbitalData(semiMajorAxis, inclination, longitudeOfAscendingNode, trueAnomaly, temptype);

                            //getting station specific data
                            string model = reader.GetString(reader.GetOrdinal("Model"));
                            string researchType = reader.GetString(reader.GetOrdinal("ResearchType"));
                            ResearchType temprt;
                            Enum.TryParse<ResearchType>(researchType, out temprt);

                            //getting telemetry data
                            double battery = reader.GetDouble(reader.GetOrdinal("BatteryLevel"));
                            double temperature = reader.GetDouble(reader.GetOrdinal("Temperature"));
                            double hullIntegrity = reader.GetDouble(reader.GetOrdinal("HullIntegrity"));
                            double boardComputerHealth = reader.GetDouble(reader.GetOrdinal("BoardComputerHealth"));

                            //constructing station with all info
                            Station station = new Station(model, temprt, name, size, mass, position, velocity, orientation, temptype,temperature, battery, boardComputerHealth, hullIntegrity);
                            //add satellite to list
                            stations.Add(station);

                        }

                    }
                }
            }
            return stations;
        }

        List<SpaceObject> ISpaceDataInterface.GetAllDebris()
        {
            List<SpaceObject> debris = new List<SpaceObject>();

            using (SqlConnection conn = new SqlConnection(Database.Connection))
            {
                conn.Open();

                string query = @"SELECT * FROM S2_Individual_SpaceObject 
                        INNER JOIN S2_Individual_OrbitalData ON S2_Individual_SpaceObject.Name = S2_Individual_OrbitalData.ObjectName 
                        LEFT JOIN S2_Individual_SpaceObject_Debris ON S2_Individual_SpaceObject.Name = S2_Individual_SpaceObject_Debris.Name 
                        WHERE S2_Individual_SpaceObject_Debris.Name IS NOT NULL";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //getting base attributes
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            double size = reader.GetDouble(reader.GetOrdinal("Size"));
                            double mass = reader.GetDouble(reader.GetOrdinal("Mass"));
                            Vector3 position = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("PositionX")),
                                (float)reader.GetDouble(reader.GetOrdinal("PositionY")),
                                (float)reader.GetDouble(reader.GetOrdinal("PositionZ"))
                            );
                            Vector3 velocity = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityX")),
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityY")),
                                (float)reader.GetDouble(reader.GetOrdinal("VelocityZ"))
                            );
                            Vector3 orientation = new Vector3(
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationX")),
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationY")),
                                (float)reader.GetDouble(reader.GetOrdinal("OrientationZ"))
                            );

                            //getting orbital data
                            string orbitType = reader.GetString(reader.GetOrdinal("OrbitType"));
                            double semiMajorAxis = reader.GetDouble(reader.GetOrdinal("SemiMajorAxis"));
                            double inclination = reader.GetDouble(reader.GetOrdinal("Inclination"));
                            double longitudeOfAscendingNode = reader.GetDouble(reader.GetOrdinal("LongitudeOfAscNode"));
                            double trueAnomaly = reader.GetDouble(reader.GetOrdinal("TrueAnomaly"));
                            OrbitType temptype;
                            Enum.TryParse<OrbitType>(orbitType, out temptype); // converting db string back to enum
                            OrbitalData orbitalData = new OrbitalData(semiMajorAxis, inclination, longitudeOfAscendingNode, trueAnomaly, temptype);

                            //getting debris specific data
                            double dangerRadius = reader.GetDouble(reader.GetOrdinal("DangerRadius"));

                            //constructing debris with all info
                            Debris debriss = new Debris(dangerRadius, name, size, mass, position, velocity, orientation, temptype);
                            //add debris to list
                            debris.Add(debriss);

                        }

                    }
                }
            }
            return debris;
        }

        void ISpaceDataInterface.DeleteObject(SpaceObject spaceObject)
        {
            if (spaceObject == null)
            {
                throw new ArgumentNullException(nameof(spaceObject), "The space object cannot be null.");
            }
            string name = spaceObject.Name;
            try
            {
                if (!DoesObjectAlreadyExist(name)) { throw new Exception("Object does not exist"); }

                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //delete from the space object table
                        string query1 = @"DELETE FROM S2_Individual_SpaceObject WHERE Name = @Name";

                        using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                        {
                            command1.Parameters.AddWithValue("@Name", name);

                            int rowsAffected = command1.ExecuteNonQuery();
                            Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject");
                        }

                        //delete from the orbital data table
                        string query2 = @"DELETE FROM S2_Individual_OrbitalData WHERE ObjectName = @Name";

                        using (SqlCommand command2 = new SqlCommand(query2, conn, transaction))
                        {
                            command2.Parameters.AddWithValue("@Name", name);

                            int rowsAffected = command2.ExecuteNonQuery();
                            Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_OrbitalData");
                        }

                        // if it is a satellite
                        string query3 = @"DELETE FROM S2_Individual_SpaceObject_Satellite WHERE Name = @Name";
                        string query4 = @"DELETE FROM S2_Individual_SpaceObject_Launch WHERE ObjectName = @Name";
                        string query5 = @"DELETE FROM S2_Individual_Satellite_TelemetryData WHERE ObjectName = @Name";

                        if (spaceObject is Satellite satellite)
                        {
                            using (SqlCommand command3 = new SqlCommand(query3, conn, transaction))
                            {
                                command3.Parameters.AddWithValue("@Name", name);

                                int rowsAffected = command3.ExecuteNonQuery();
                                Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject_Satellite");
                            }
                            using (SqlCommand command4 = new SqlCommand(query4, conn, transaction))
                            {
                                command4.Parameters.AddWithValue("@Name", name);

                                int rowsAffected = command4.ExecuteNonQuery();
                                Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject_Satellite");
                            }
                            using (SqlCommand command5 = new SqlCommand(query5, conn, transaction))
                            {
                                command5.Parameters.AddWithValue("@Name", name);

                                int rowsAffected = command5.ExecuteNonQuery();
                                Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject_Satellite");
                            }
                        }
                        //if it is a station
                        string query6 = @"DELETE FROM S2_Individual_SpaceObject_Station WHERE Name = @Name";
                        string query7 = @"DELETE FROM S2_Individual_Station_TelemetryData WHERE ObjectName = @Name";
                        if (spaceObject is Station station)
                        {
                            using (SqlCommand command6 = new SqlCommand(query6, conn, transaction))
                            {
                                command6.Parameters.AddWithValue("@Name", name);

                                int rowsAffected = command6.ExecuteNonQuery();
                                Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject_Satellite");
                            }
                            using (SqlCommand command7 = new SqlCommand(query7, conn, transaction))
                            {
                                command7.Parameters.AddWithValue("@Name", name);

                                int rowsAffected = command7.ExecuteNonQuery();
                                Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject_Satellite");
                            }
                        }
                        //if it is debris
                        string query8 = @"DELETE FROM S2_Individual_SpaceObject_Debris WHERE Name = @Name";
                        if (spaceObject is Debris debris)
                        {
                            using (SqlCommand command8 = new SqlCommand(query8, conn, transaction))
                            {
                                command8.Parameters.AddWithValue("@Name", name);

                                int rowsAffected = command8.ExecuteNonQuery();
                                Console.WriteLine($"Deleted {rowsAffected} row(s) from S2_Individual_SpaceObject_Satellite");
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting object: {ex.Message}");
            }
        }

        void ISpaceDataInterface.UpdateObject(string name, SpaceObject spaceObject)
        {
            try
            {
                if (!DoesObjectAlreadyExist(name)) { throw new Exception("Object does not exist"); }
                if(name != spaceObject.Name) //name is being changed
                    if(DoesObjectAlreadyExist(spaceObject.Name)) { throw new ArgumentException("Object with that name already exists"); }

                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query = @"UPDATE S2_Individual_SpaceObject 
                             SET Name = @NewName, Size = @Size, Mass = @Mass, PositionX = @PositionX, PositionY = @PositionY, PositionZ = @PositionZ, 
                                 VelocityX = @VelocityX, VelocityY = @VelocityY, VelocityZ = @VelocityZ, OrientationX = @OrientationX, OrientationY = @OrientationY, 
                                 OrientationZ = @OrientationZ
                             FROM S2_Individual_SpaceObject s2
                             INNER JOIN S2_Individual_OrbitalData s3 ON s2.Name = s3.ObjectName
                             ";

                        using (SqlCommand command = new SqlCommand(query, conn, transaction))
                        {
                            command.Parameters.AddWithValue("@NewName", spaceObject.Name);
                            command.Parameters.AddWithValue("@Size", spaceObject.Size);
                            command.Parameters.AddWithValue("@Mass", spaceObject.Mass);
                            command.Parameters.AddWithValue("@PositionX", spaceObject.Position.X);
                            command.Parameters.AddWithValue("@PositionY", spaceObject.Position.Y);
                            command.Parameters.AddWithValue("@PositionZ", spaceObject.Position.Z);
                            command.Parameters.AddWithValue("@VelocityX", spaceObject.Velocity.X);
                            command.Parameters.AddWithValue("@VelocityY", spaceObject.Velocity.Y);
                            command.Parameters.AddWithValue("@VelocityZ", spaceObject.Velocity.Z);
                            command.Parameters.AddWithValue("@OrientationX", spaceObject.Orientation.X);
                            command.Parameters.AddWithValue("@OrientationY", spaceObject.Orientation.Y);
                            command.Parameters.AddWithValue("@OrientationZ", spaceObject.Orientation.Z);
                            command.Parameters.AddWithValue("@Name", name);

                            if (spaceObject is Satellite satellite)
                            {
                                command.CommandText += @"
                                 LEFT JOIN S2_Individual_SpaceObject_Satellite s4 ON s2.Name = s4.Name
                                 LEFT JOIN S2_Individual_Launch s5 ON s2.Name = s5.ObjectName
                                 LEFT JOIN S2_Individual_Satellite_TelemetryData s6 ON s2.Name = s6.ObjectName
                                 WHERE s4.Name = @Name
                                 AND s5.ObjectName = @Name
                                 AND s6.ObjectName = @Name
                                 AND s2.Name = @Name";

                                command.Parameters.AddWithValue("@Model", satellite.Model);
                                command.Parameters.AddWithValue("@Manufacturer", satellite.Manufacturer);
                                command.Parameters.AddWithValue("@Objective", satellite.Objective);
                                command.Parameters.AddWithValue("@LaunchDate", satellite.LaunchData.LaunchDate.ToString("yyyy-MM-dd HH:mm:ss") ?? "NULL");
                                command.Parameters.AddWithValue("@LaunchPositionX", satellite.LaunchData.LaunchLocation.X);
                                command.Parameters.AddWithValue("@LaunchPositionY", satellite.LaunchData.LaunchLocation.Y);
                                command.Parameters.AddWithValue("@LaunchPositionZ", satellite.LaunchData.LaunchLocation.Z);
                                command.Parameters.AddWithValue("@LandingDate", satellite.LaunchData.LandingDate != null ? (object)DateTime.Parse(satellite.LaunchData.LandingDate?.ToString("yyyy-MM-dd HH:mm:ss")) : DBNull.Value);
                                command.Parameters.AddWithValue("@Temperature", satellite.TelemetryData.Temperature);
                                command.Parameters.AddWithValue("@BatteryLevel", satellite.TelemetryData.BatteryLevel);
                                command.Parameters.AddWithValue("@HullIntegrity", satellite.TelemetryData.HullIntegrity);
                                command.Parameters.AddWithValue("@BoardComputerHealth", satellite.TelemetryData.BoardComputerHealth);
                                command.Parameters.AddWithValue("@ObjectName", spaceObject.Name);
                            }
                            else if (spaceObject is Station st)
                            {
                                command.CommandText += @"
                                 LEFT JOIN S2_Individual_SpaceObject_Station s4 ON s2.Name = s4.Name
                                 LEFT JOIN S2_Individual_Station_TelemetryData s6 ON s2.Name = s6.ObjectName
                                 WHERE s4.Name = @Name
                                 AND s6.ObjectName = @Name
                                    AND s2.Name = @Name";

                                command.Parameters.AddWithValue("@Model", st.Model);
                                command.Parameters.AddWithValue("@ResearchType", st.ResearchType.ToString());
                                command.Parameters.AddWithValue("@Temperature", st.TelemetryData.Temperature);
                                command.Parameters.AddWithValue("@BatteryLevel", st.TelemetryData.BatteryLevel);
                                command.Parameters.AddWithValue("@HullIntegrity", st.TelemetryData.HullIntegrity);
                                command.Parameters.AddWithValue("@BoardComputerHealth", st.TelemetryData.BoardComputerHealth);
                            }
                            else if(spaceObject is Debris d)
                            {
                                command.CommandText += @"
                                 LEFT JOIN S2_Individual_SpaceObject_Debris s4 ON s2.Name = s4.Name
                                 WHERE s4.Name = @Name
                                    AND s2.Name = @Name";

                                command.Parameters.AddWithValue("@DangerRadius", d.DangerRadius);

                            }

                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"Updated {rowsAffected} row(s)");
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
