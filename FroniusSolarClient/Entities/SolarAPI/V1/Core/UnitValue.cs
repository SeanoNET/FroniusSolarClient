namespace FroniusSolarClient.Entities.SolarAPI.V1
{
    public class UnitValue<T>
    {
        /// <summary>
        /// Unit name
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Unit value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Provides a string representation of the Unit
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }
}