using System;
using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс обеспечивающий запуск программы KOMPAS-3D.
    /// </summary>
    public class Kompas
    {
        /// <summary>
        /// Поля класса.
        /// </summary>
        private KompasObject _kompasObject;
        private ksDocument3D _ksDocumentObject;

        public KompasObject KompasObj
        {
            get
            {
                return _kompasObject;
            }
            set
            {
                _kompasObject = value;
            }
        }
        public ksDocument3D KsDocumentObj
        {
            get
            {
                return _ksDocumentObject;
            }
            set
            {
                _ksDocumentObject = value;
            }
        }

        /// <summary>
        /// Метод, открывающий программу KOMPAS-3D.
        /// </summary>
        public void OpenKompas3D()
        {
            if (_kompasObject == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(type);
            }
            if (_kompasObject != null)
            {
                try
                {
                    _kompasObject.Visible = true;
                    _kompasObject.ActivateControllerAPI();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Метод создания документа.
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                if(_kompasObject != null)
                {
                    CloseDocument();
                    if (_ksDocumentObject == null)
                    {
                        _ksDocumentObject = (ksDocument3D) _kompasObject.Document3D();
                        _ksDocumentObject.Create(false, false);
                        _ksDocumentObject = (ksDocument3D)_kompasObject.ActiveDocument3D();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException(@"Сначала откройте KOMPAS 3D");
            }
        }

        /// <summary>
        /// Метод закрытия документа.
        /// </summary>
        public void CloseDocument()
        {
            if(_ksDocumentObject != null)
            {
                _ksDocumentObject.close();
                _ksDocumentObject = null;
            }
        }

        /// <summary>
        /// Метод закрытия программы KOMPAS-3D.
        /// </summary>
        public void CloseKompas3D()
        {
            if (_ksDocumentObject != null)
            {
                CloseDocument();
            }
            try
            {
                _kompasObject.Quit();
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}
