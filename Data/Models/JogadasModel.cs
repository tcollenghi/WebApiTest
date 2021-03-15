using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models
{
    [Serializable]
    public class JogadasModel
    {
        public JogadasModel()
        { }

        public JogadasModel(int id, string jogada)
        {
            this.id = id;
            this.Jogada = jogada;
        }

        #region Instance Properties

        [Display(Name = "id")]
        [Required]
        public Int32 id { get; set; }

        [Display(Name = "Jogada")]
        [Required, StringLength(100)]
        public String Jogada { get; set; }

        [Display(Name = "Jogador")]
        [StringLength(100)]
        public String Jogador { get; set; }

        #endregion Instance Properties
    }
}