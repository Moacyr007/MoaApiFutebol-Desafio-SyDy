namespace Domain.Entities
{
    public class PartidaEntity : BaseEntity
    {
        //o construtur tem que ter o context algo assim pra funcionar com a migration
        //public PartidaEntity(TimeEntity time1, int gols1, TimeEntity time2, int gols2)
        //{
        //    Time1 = time1;
        //    Gols1 = gols1;
        //    Time2 = time2;
        //    Gols2 = gols2;
        //}

        public TimeEntity Time1 { get; set; }
        public int Gols1 { get; set; }
        public TimeEntity Time2 { get; set; }
        public int Gols2 { get; set; }
    }
}
