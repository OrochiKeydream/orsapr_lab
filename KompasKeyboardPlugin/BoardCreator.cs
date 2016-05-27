using System;
using System.CodeDom;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using System.Collections.Generic;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, создающий клавиатурную секцию.
    /// </summary>
    public class BoardCreator : KeyboardPartBase
    {
        #region Поля класса.

        /// <summary>
        /// Расстояние-зазор между клавишами.
        /// </summary>
        private const double _space = 0.1;

        /// <summary>
        /// Высота клавишной секции.
        /// </summary>
        private const double _keyboardHeight = 3.5;

        /// <summary>
        /// Отступ слева, который увеличивается при построении клавиш.
        /// </summary>
        private double _marginLeft;

        #endregion

        /// <summary>
        /// Метод, строящий клавиатурную секцию.
        /// </summary>
        /// <param name="document3D">Указатель на активный документ КОМПАС-3D.</param>
        /// <param name="data">Указатель на данные.</param>
        public override void Build(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            if (document3D == null || data == null)
            {
                throw new NullReferenceException("Метод ссылается на null объект.");
            }

            // Текущая обрабатываемая клавиша.
            KeyNote currentKey = SetCurrentNote(data);
            Method2(document3D, data, currentKey);
        }

        /// <summary>
        /// Метод, устанавливающий начальную клавишу для клавиатуры.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private KeyNote SetCurrentNote(KeyboardParametersStorage data)
        {
            switch (data.KeyboardKeyAmount)
            {
                case 88:
                {
                    return KeyNote.A;
                }
                case 76:
                {
                    return KeyNote.A;
                }
                case 61:
                {
                    return KeyNote.C;
                }
            }
            throw new Exception();
        }

        void Method2(ksDocument3D document3D,
            KeyboardParametersStorage data, KeyNote currentKey)
        {
            switch (data.KeyboardType)
            {
                case KeyboardType.Piano:
                {
                    KeyBuild(document3D, data, currentKey, true,
                        _keyboardHeight, KeyLevel.Middle);

                    KeyBuild(document3D, data, currentKey, true, 1.5);

                    // Если первая клавиша ДО (C), то первая черная клавиша -
                    // РЕ -БЕМОЛЬ (Db).
                    // Если первая клавиша ЛЯ (A), то первая черная клавиша -
                    // СИ -БЕМОЛЬ (Bb).
                    //
                    if (currentKey == KeyNote.C)
                    {
                        currentKey = KeyNote.Db;
                    }
                    else
                    {
                        if (currentKey == KeyNote.A)
                        {
                            currentKey = KeyNote.Bb;
                        }
                    }

                    KeyBuild(document3D, data, currentKey, false,
                        _keyboardHeight);
                    break;
                }
                case KeyboardType.Synth:
                {
                    KeyBuild(document3D, data, currentKey, true,
                        _keyboardHeight, KeyLevel.Bottom);

                    KeyBuild(document3D, data, currentKey, true, 2.0,
                        KeyLevel.Middle);

                    KeyBuild(document3D, data, currentKey, true, 1.5);

                    if (currentKey == KeyNote.C)
                    {
                        currentKey = KeyNote.Db;
                    }
                    else
                    {
                        if (currentKey == KeyNote.A)
                        {
                            currentKey = KeyNote.Bb;
                        }
                    }

                    KeyBuild(document3D, data, currentKey, false,
                        _keyboardHeight);
                    break;
                }
            }
        }

        /// <summary>
        /// Метод, рисующий линии белой клавиши для эскиза.
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="data">Указатель на данные.</param>
        /// <param name="currentKey">Текущая клавиша.</param>
        /// <param name="count">Номер текущей клавиши.</param>
        /// <param name="marginFront">Фронтальный отступ.</param>
        private KeyCreatorBase KeyLineDraw(ksDocument2D sketch,
            KeyboardParametersStorage data, KeyNote currentKey, int count,
            double marginFront)
        {
            switch (currentKey)
            {
                case KeyNote.C:
                {
                    if (count + 1 == data.WhiteKeyAmount)
                    {
                        return new KeyCreatorCAdditional(sketch,
                            _marginLeft, marginFront);
                    }
                    return new KeyCreatorC(sketch, _marginLeft,
                        marginFront);
                }
                case KeyNote.D:
                {
                    return new KeyCreatorD(sketch, _marginLeft,
                        marginFront);
                }
                case KeyNote.E:
                {
                    return new KeyCreatorE(sketch, _marginLeft,
                        marginFront);
                }
                case KeyNote.F:
                {
                    return new KeyCreatorF(sketch, _marginLeft,
                        marginFront);
                }
                case KeyNote.G:
                {
                    return new KeyCreatorG(sketch, _marginLeft,
                        marginFront);
                }
                case KeyNote.A:
                {
                    if (count == 0)
                    {
                        return new KeyCreatorAAdditional(sketch,
                            _marginLeft, marginFront);
                    }
                    return new KeyCreatorA(sketch, _marginLeft,
                        marginFront);
                }
                case KeyNote.B:
                {
                    return new KeyCreatorB(sketch, _marginLeft,
                        marginFront);
                }
                default:
                {
                    throw new Exception("TODO");
                }
            }
        }

        /// <summary>
        /// Метод, рисующий линии черной клавиши для эскиза.
        /// </summary>
        /// <param name="sketch">Указатель на эскиз.</param>
        /// <param name="data">Указатель на данные.</param>
        /// <param name="currentKey">Текущая клавиша.</param>
        private KeyCreatorBase KeyLineDraw(ksDocument2D sketch, KeyNote currentKey)
        {
            switch (currentKey)
            {
                case KeyNote.Db:
                {
                    return new KeyCreatorDb(sketch, _marginLeft);
                }
                case KeyNote.Eb:
                {
                    return new KeyCreatorEb(sketch, _marginLeft);
                }
                case KeyNote.Gb:
                {
                    return new KeyCreatorGb(sketch, _marginLeft);
                }
                case KeyNote.Ab:
                {
                    return new KeyCreatorAb(sketch, _marginLeft);
                }
                case KeyNote.Bb:
                {
                    return new KeyCreatorBb(sketch, _marginLeft);
                }
                default:
                {
                    throw new Exception("TODO");
                }
            }
        }

        /// <summary>
        /// Метод, рисующий эскиз клавиш.
        /// </summary>
        /// <param name="document3D">Указатель на активный документ КОМПАС-3D.</param>
        /// <param name="data">Указатель на данные.</param>
        /// <param name="currentKey">Текущая клавиша.</param>
        /// <param name="isWhiteKey">Принадлежность к белым клавишам.</param>
        /// <param name="keyboardHeight">Высота клавиатурной секции.</param>
        /// <param name="keyLevel">Уровень клавиши.</param>
        private void KeyBuild(ksDocument3D document3D,
            KeyboardParametersStorage data, KeyNote currentKey,
            bool isWhiteKey, double keyboardHeight,
            KeyLevel keyLevel = KeyLevel.Top)
        {
            // Установка фронтального отступа в зависимости от выбранного
            // уровня клавиш.
            //
            double marginTop;

            var keyMarginTopDictionary = new Dictionary<KeyLevel, double>()
            {
                { KeyLevel.Bottom, 3.6 },
                { KeyLevel.Middle, 0.6 },
                { KeyLevel.Top, 0.5 }
            };

            marginTop = keyMarginTopDictionary[keyLevel];

            // Сброс отступа.
            _marginLeft = -(data.BodyLength / 2) + (data.BoardLength / 2)
                - _space;

            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);
            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    offsetDef.direction = true;
                    offsetDef.offset = data.BodyHeight - keyboardHeight;

                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                    basePlane.name = "Начальная плоскость";
                    offsetDef.SetPlane(basePlane);

                    entityOffsetPlane.name = "Смещенная плоскость";
                    entityOffsetPlane.hidden = true;
                    entityOffsetPlane.Create();
                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        sketchDef.SetPlane(entityOffsetPlane);
                        entitySketch.Create();
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        if (isWhiteKey)
                        {
                            entitySketch.name = "Белые клавиши";
                            for (int count = 0; count < data.WhiteKeyAmount;
                                count++)
                            {
                                KeyLineDraw(sketchEdit, data, currentKey,
                                    count, marginTop).Build();
                                _marginLeft = _marginLeft - 2.2 - _space;

                                // Сброс последовательности клавиш.
                                //
                                if (currentKey == KeyNote.B)
                                {
                                    currentKey = KeyNote.C;
                                }
                                else
                                {
                                    currentKey++;
                                }
                            }
                        }
                        else
                        {
                            entitySketch.name = "Черные клавиши";
                            for (int count = 0; count < data.BlackKeyAmount;
                                count++)
                            {
                                // Для ровного отображения черных клавиш
                                // относительно белых, необходимо задать
                                // отступ после каждой клавиши.
                                //
                                if (count == 0 && currentKey == KeyNote.Db)
                                {
                                    _marginLeft = _marginLeft - 2.2 - _space;
                                }
                                else if (currentKey == KeyNote.Db
                                    || currentKey == KeyNote.Gb)
                                {
                                    _marginLeft = _marginLeft - (2.2
                                        + _space) * 2;
                                }
                                else
                                {
                                    _marginLeft = _marginLeft - 2.2
                                        - _space;
                                }
                                KeyLineDraw(sketchEdit, currentKey).Build();

                                // Следующей после СИ-БЕМОЛЬ черной клавишей
                                // является РЕ-БЕМОЛЬ.
                                //
                                if (currentKey == KeyNote.Bb)
                                {
                                    currentKey = KeyNote.Db;
                                }
                                else
                                {
                                    currentKey++;
                                }
                            }
                        }
                        sketchDef.EndEdit();
                        if (isWhiteKey)
                        {
                            KeyExtruse(part, entitySketch, data,
                                isWhiteKey, keyLevel);
                        }
                        else
                        {
                            KeyExtruse(part, entitySketch, data,
                                isWhiteKey);
                            BlackKeyCutSketch(document3D, data);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод выдавливания клавиш.
        /// </summary>
        /// <param name="part">Указатель на компонент.</param>
        /// <param name="entity">Указатель на эскиз.</param>
        private void KeyExtruse(ksPart part, ksEntity entity,
            KeyboardParametersStorage data, bool isWhiteKey,
            KeyLevel keyLevel = KeyLevel.Top)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            if (entityExtrusion != null)
            {
                var extrusionDefinition = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {
                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    if (isWhiteKey)
                    {
                        entityExtrusion.name = "Выдавливание белых клавиш";
                        entityExtrusion.SetAdvancedColor(Color.FromArgb(254,
                            254, 254).ToArgb(), .0, .0, .0, .0, 100, 100);

                        var keyLevelDictionary = new Dictionary<KeyLevel, double>()
                        {
                            { KeyLevel.Bottom, 1.5},
                            { KeyLevel.Middle, data.KeyboardType == KeyboardType.Piano
                                                ? 2.0
                                                : 0.5},
                            { KeyLevel.Top, 0.1}
                        };
                        extrusionDefinition.SetSideParam(true,
                            (short)End_Type.etBlind,
                            keyLevelDictionary[keyLevel]);
                    }
                    else
                    {
                        entityExtrusion.name = "Выдавливание черных клавиш";
                        entityExtrusion.SetAdvancedColor(Color.FromArgb(20,
                            20, 20).ToArgb(), .0, .0, .0, .0, 100, 100);
                        extrusionDefinition.SetSideParam(true,
                            (short)End_Type.etBlind, 3.4);
                    }
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);
                    entityExtrusion.Create();
                }
            }
        }

        private void OffsetSketchSet(ksDocument3D document3D,
            KeyboardParametersStorage data, string sketchName,
            double offset, Obj3dType obj3DType)
        {
            SketchType sketchType = SketchType.BlackKeyCut;


            part = (ksPart) document3D.GetPart((short) Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity) part.NewEntity((short) Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity) part.NewEntity((short) Obj3dType.o3d_sketch);
            entitySketch.name = sketchName;
            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition) entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    offsetDef.direction = true;
                    offsetDef.offset = offset;

                    var basePlane = (ksEntity) part.GetDefaultEntity((short) obj3DType);
                    basePlane.name = "Начальная плоскость";

                    offsetDef.SetPlane(basePlane);

                    entityOffsetPlane.name = "Смещенная плоскость";
                    entityOffsetPlane.hidden = true;
                    entityOffsetPlane.Create();

                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        sketchDef.SetPlane(entityOffsetPlane);
                        entitySketch.Create();

                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        LineDraw(sketchEdit, data, sketchType);

                        sketchDef.EndEdit();
                        BlackKeyCut(part, entitySketch, data);
                    }
                }
            }
        }

        private void LineDraw(ksDocument2D sketch,
            KeyboardParametersStorage data, SketchType sketchType)
        {
            switch (sketchType)
            {
                case SketchType.BlackKeyCut:
                {
                        sketch.ksLineSeg(-data.BodyHeight + 0.1, 5.5,
                            -data.BodyHeight + 0.1, 6.5, 1);
                        sketch.ksLineSeg(-data.BodyHeight + 0.1, 6.5,
                            -data.BodyHeight + 1.4, 5.5, 1);
                        sketch.ksLineSeg(-data.BodyHeight + 1.4, 5.5,
                            -data.BodyHeight + 0.1, 5.5, 1);

                        sketch.ksLineSeg(-data.BodyHeight + 0.1, 15.5,
                            -data.BodyHeight + 0.1, 15.0, 1);
                        sketch.ksLineSeg(-data.BodyHeight + 0.1, 15.0,
                            -data.BodyHeight + 1.375, 15.0, 1);
                        sketch.ksLineSeg(-data.BodyHeight + 1.375, 15.0,
                            -data.BodyHeight + 1.375, 15.5, 1);
                        sketch.ksLineSeg(-data.BodyHeight + 1.375, 15.5,
                            -data.BodyHeight + 0.1, 15.5, 1);
                        break;
                }
                default:
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Метод, строящий эскиз для вырезания скоса у черных клавиш.
        /// </summary>
        /// <param name="document3D">Указатель на активный документ КОМПАС-3D.</param>
        /// <param name="data">Указатель на данные.</param>
        private void BlackKeyCutSketch(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            string name = "Черные клавиши";
            double offset = (data.BodyLength/2) - (data.BoardLength/2)
                            + _space;
            OffsetSketchSet(document3D, data, name, offset, Obj3dType.o3d_planeYOZ);
        }

        /// <summary>
        /// Метод вырезания скоса у черных клавиш.
        /// </summary>
        /// <param name="part">Указатель на компонент.</param>
        /// <param name="entity">Указатель на эскиз.</param>
        /// <param name="data">Указатель на данные.</param>
        private void BlackKeyCut(ksPart part, ksEntity entity,
            KeyboardParametersStorage data)
        {
            var entityCut = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (entityCut != null)
            {
                entityCut.name = "Вырезание черных клавиш";
                var cutDefinition = (ksCutExtrusionDefinition)entityCut.GetDefinition();
                if (cutDefinition != null)
                {
                    cutDefinition.directionType = (short)Direction_Type.dtReverse;
                    cutDefinition.SetSideParam(false, (short)End_Type.etBlind,
                        data.BoardLength - _space);
                    cutDefinition.SetSketch(entity);

                    entityCut.SetAdvancedColor(Color.FromArgb(20, 20, 20).ToArgb(),
                        .0, .0, .0, .0, 100, 100);
                    entityCut.Create();
                }
            }
        }
    }
}
