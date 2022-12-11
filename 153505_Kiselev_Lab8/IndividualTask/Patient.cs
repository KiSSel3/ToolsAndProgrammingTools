namespace IndividualTask
{
    [Serializable]
    public class Patient
    {
        public Patient() { }
        public Patient(int id, string name, string diagnosis) => (Id, Name, Diagnosis) = (id, name, diagnosis);

        public int Id { get; set; } = default;
        public string Name { get; set; } = default;
        public string Diagnosis { get; set; } = default;      
    }
}