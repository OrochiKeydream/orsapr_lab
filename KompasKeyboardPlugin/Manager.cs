using Kompas6API5;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, управляющий процессом создания модели.
    /// </summary>
    public class Manager
    {
        #region Поля класса.

        /// <summary>
        /// Указатель на данные о клавиатуре.
        /// </summary>
        private KeyboardParametersStorage _keyboardDataObject
            = new KeyboardParametersStorage();

        public KeyboardParametersStorage KeyboardData
        {
            get
            {
                return _keyboardDataObject;
            }
        }

        /// <summary>
        /// Указатель на документ КОМПАС-3D.
        /// </summary>
        private Kompas _keyboardKsObject = new Kompas();

        public Kompas KeyboardKompas
        {
            get
            {
                return _keyboardKsObject;
            }
        }

        /// <summary>
        /// Модель тела клавиатуры.
        /// </summary>
        private BodyCreator _bodyObject = new BodyCreator();

        /// <summary>
        /// Модель клавишной секции клавиатуры.
        /// </summary>
        private BoardCreator _boardObject = new BoardCreator();

        /// <summary>
        /// Модель панели управления клавиатуры.
        /// </summary>
        private PanelCreator _panelObject = new PanelCreator();

        /// <summary>
        /// Модель коммутационной панели клавиатуры.
        /// </summary>
        private CommutationCreator _commutationObject
            = new CommutationCreator();

        #endregion

        /// <summary>
        /// Метод построения модели.
        /// </summary>
        public void ModelBuild()
        {
            _bodyObject.Build(_keyboardKsObject.KsDocumentObj,
                _keyboardDataObject);
            _boardObject.Build(_keyboardKsObject.KsDocumentObj,
                _keyboardDataObject);
            _panelObject.Build(_keyboardKsObject.KsDocumentObj,
                _keyboardDataObject);
            _commutationObject.Build(_keyboardKsObject.KsDocumentObj,
                _keyboardDataObject);
        }

        public void OpenKompas()
        {
            KeyboardKompas.OpenKompas3D();
        }

        public void KsObjectSetNull()
        {
            KeyboardKompas.KompasObj = null;
            KeyboardKompas.KsDocumentObj = null;
        }
    }
}
