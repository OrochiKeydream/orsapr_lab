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
        /// 
        /// </summary>
        public KompasObject KompasObj { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ksDocument3D KsDocumentObj { get; set; }

        /// <summary>
        /// Метод, открывающий программу KOMPAS-3D.
        /// </summary>
        public void OpenKompas3D()
        {
            if (KompasObj == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                KompasObj = (KompasObject)Activator.CreateInstance(type);
            }
            if (KompasObj != null)
            {
                try
                {
                    KompasObj.Visible = true;
                    KompasObj.ActivateControllerAPI();
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
                if(KompasObj != null)
                {
                    CloseDocument();
                    if (KsDocumentObj == null)
                    {
                        KsDocumentObj = (ksDocument3D) KompasObj.Document3D();
                        KsDocumentObj.Create(false, false);
                        KsDocumentObj = (ksDocument3D)KompasObj.ActiveDocument3D();
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
            if(KsDocumentObj != null)
            {
                KsDocumentObj.close();
                KsDocumentObj = null;
            }
        }

        /// <summary>
        /// Метод закрытия программы KOMPAS-3D.
        /// </summary>
        public void CloseKompas3D()
        {
            if (KsDocumentObj != null)
            {
                CloseDocument();
            }
            try
            {
                KompasObj.Quit();
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}
