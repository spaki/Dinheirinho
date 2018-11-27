using SQLite;
using System;
using System.ComponentModel;

namespace Dinheirinho.Models
{
    public class Movimentacao : INotifyPropertyChanged
    {
        private string _tipo;
        private string _foto;

        public Movimentacao()
        {
            Ativa = true;
            Data = DateTime.Now;
            Tipo = "Saída";
        }

        [PrimaryKey]
        public virtual Guid Id { get; set; }
        public virtual string Descricao { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual bool Ativa { get; set; }
        public virtual DateTime Data { get; set; }

        public virtual Guid? IdNoServidor { get; set; }
        public virtual DateTime? DataSincronizacao { get; set; }

        public virtual string Foto
        {
            get => _foto;
            set
            {
                _foto = value;
                OnPropertyChanged("Foto");
            }
        }

        public virtual string Tipo
        {
            get => _tipo;
            set
            {
                _tipo = value;
                OnPropertyChanged("Tipo");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
