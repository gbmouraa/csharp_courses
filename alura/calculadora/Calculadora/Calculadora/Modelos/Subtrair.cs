using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Modelos
{
    internal class Subtrair : Menu
    {
        public override void Executar()
        {
            base.Executar();
            var nums = base.PegaNumeros();

            Console.WriteLine($"{nums[0]} - {nums[1]} = {nums[0] - nums[1]}");
        }
    }
}
