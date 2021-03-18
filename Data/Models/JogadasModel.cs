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

        public JogadasModel(string jogada, string jogador, string email)
        {
            this.Jogada = jogada;
            this.NomeJogador = jogador;
            this.Email = email;
        }

        #region Instance Properties

        [Display(Name = "id")]
        [Required]
        public int id { get; set; }

        [Display(Name = "Jogada")]
        [Required, StringLength(100)]
        public string Jogada { get; set; }

        [Display(Name = "Jogador")]
        [StringLength(100)]
        public string NomeJogador { get; set; }

        [Display(Name = "email")]
        [StringLength(50)]
        public string Email { get; set; }

        #endregion Instance Properties
    }
}