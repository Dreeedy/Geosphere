using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geosphere
{
    /// <summary>
    /// Абстрактный класс SaveHandler, объявляет общий функционал для возможных реализаций сохранения файла,
    /// что позволит, при необходимости, реализовать разные способы сохранения файла
    /// </summary>
    abstract class SaveHandler
    {
        abstract public void Save(string data, string fileName);
    }
}
