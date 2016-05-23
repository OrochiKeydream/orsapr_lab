using System;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, создающий панель управления клавиатуры.
    /// </summary>
    public class PanelCreator : KeyboardPartBase
    {
        /// <summary>
        /// Метод, создающий панель управления клавиатуры.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        public override void Build(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            if (document3D == null || data == null)
            {
                throw new NullReferenceException("Метод ссылается на null объект.");
            }

            if (data.PanelDisplay == true)
            {
                DisplayBuild(document3D, data);
            }
            if (data.PanelButtons == true)
            {
                ButtonsBuild(document3D, data);
            }
            if (data.PanelKnobs == true)
            {
                KnobsBuild(document3D, data);
            }
            if (data.PanelWheel != WheelSetup.Disable)
            {
                WheelSpaceBuild(document3D, data);
                WheelBuild(document3D, data);
            }
        }

        /// <summary>
        /// Метод, строящий дисплей.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void DisplayBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            // Переменные центрования.
            //
            double horCenter = data.BodyLength / 2;
            double verCenter = data.BodyDepth - ((data.BodyDepth - 15.5)
                / 2);

            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            entitySketch.name = "Дисплей";

            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                    basePlane.name = "Начальная плоскость";

                    offsetDef.direction = true;
                    offsetDef.offset = data.BodyHeight;
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

                        sketchEdit.ksLineSeg(- horCenter + 5.0, - verCenter
                            + 3.0, - horCenter + 5.0, - verCenter - 3.0, 1);
                        sketchEdit.ksLineSeg(- horCenter + 5.0, - verCenter
                            - 3.0, - horCenter - 5.0, - verCenter - 3.0, 1);
                        sketchEdit.ksLineSeg(- horCenter - 5.0, - verCenter
                            - 3.0, - horCenter - 5.0, - verCenter + 3.0, 1);
                        sketchEdit.ksLineSeg(- horCenter - 5.0, - verCenter
                            + 3.0, - horCenter + 5.0, - verCenter + 3.0, 1);

                        sketchDef.EndEdit();
                        DisplayExtruse(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод выдавливания дисплея.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void DisplayExtruse(ksPart part, ksEntity entity)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            if (entityExtrusion != null)
            {
                entityExtrusion.name = "Выдавливание дисплея";

                var extrusionDefinition = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {
                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    extrusionDefinition.SetSideParam(true,
                        (short)End_Type.etBlind, 0.1);
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);

                    entityExtrusion.SetAdvancedColor(Color.FromArgb(40, 40, 40).ToArgb(),
                        .0, .0, .0, .0, 100, 100);
                    entityExtrusion.Create();
                }
            }
        }

        /// <summary>
        /// Метод строящий кнопки.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void ButtonsBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            // Переменные центрования.
            //
            double horCenter = data.BodyLength / 2;
            double verCenter = data.BodyDepth - ((data.BodyDepth - 15.5)
                / 2);

            // Переменные отступов.
            //
            double horMargin = horCenter + 10.0;
            double verMargin = verCenter + 3.0;

            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            entitySketch.name = "Кнопки";

            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                    basePlane.name = "Начальная плоскость";

                    offsetDef.direction = true;
                    offsetDef.offset = data.BodyHeight;
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

                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                sketchEdit.ksLineSeg(- horMargin,
                                    - verMargin, - horMargin - 1.0,
                                    - verMargin, 1);
                                sketchEdit.ksLineSeg(- horMargin - 1.0,
                                    - verMargin, - horMargin - 1.0,
                                    - verMargin + 0.5, 1);
                                sketchEdit.ksLineSeg(- horMargin - 1.0,
                                    - verMargin + 0.5, - horMargin,
                                    - verMargin + 0.5, 1);
                                sketchEdit.ksLineSeg(- horMargin, - verMargin
                                    + 0.5, - horMargin, - verMargin, 1);

                                // Проивзодим обновление горизонтального
                                // отступа для построения следующей
                                // кнопки.
                                horMargin += 3;
                            }
                            // Производим сбрасывание отступа по горизонтали,
                            // а так же производим обновление отступа по
                            // вертикали для построения следующего ряда
                            // кнопок.
                            // 
                            horMargin = horCenter + 10.0;
                            verMargin -= 1.8;
                        }
                        sketchDef.EndEdit();
                        ButtonsExtruse(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод выдавливания кнопок.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void ButtonsExtruse(ksPart part, ksEntity entity)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            if (entityExtrusion != null)
            {
                entityExtrusion.name = "Выдавливание кнопок";

                var extrusionDefinition = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {
                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    extrusionDefinition.SetSideParam(true,
                        (short)End_Type.etBlind, 0.2);
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);

                    entityExtrusion.SetAdvancedColor(Color.FromArgb(80, 80, 80).ToArgb(),
                        .0, .0, .0, .0, 100, 100);
                    entityExtrusion.Create();
                }
            }
        }

        /// <summary>
        /// Метод, строящий ручки.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void KnobsBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            // Переменные центрования.
            //
            double horCenter = data.BodyLength / 2;
            double verCenter = data.BodyDepth - ((data.BodyDepth - 15.5)
                / 2);

            // Переменные отступов.
            //
            double horMargin = horCenter - 10.0;
            double verMargin = verCenter + 3.0;

            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            entitySketch.name = "Ручки";

            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                    basePlane.name = "Начальная плоскость";

                    offsetDef.direction = true;
                    offsetDef.offset = data.BodyHeight;
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

                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                sketchEdit.ksCircle(- horMargin + 0.25,
                                    - verMargin + 0.25, 0.5, 1);

                                // Производим обновление горизонтального
                                // отступа для построения следующей
                                // ручки.
                                horMargin -= 3;
                            }
                            // Производим сброс горизонтального отступа
                            // и обновление вертикального отступа для
                            // построения следующего ряда ручек.
                            //
                            horMargin = horCenter - 10.0;
                            verMargin -= 3.0;
                        }
                        sketchDef.EndEdit();
                        KnobsExtruse(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод выдавливания ручек.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void KnobsExtruse(ksPart part, ksEntity entity)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            if (entityExtrusion != null)
            {
                entityExtrusion.name = "Выдавливание ручек";

                var extrusionDefinition = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {
                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    extrusionDefinition.SetSideParam(true,
                        (short)End_Type.etBlind, 1.0);
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);

                    entityExtrusion.SetAdvancedColor(Color.FromArgb(80, 80, 80).ToArgb(),
                        .0, .0, .0, .0, 100, 100);
                    entityExtrusion.Create();
                }
            }
        }

        /// <summary>
        /// Метод, создающий пространство для колеса модуляции.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void WheelSpaceBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            entitySketch.name = "Колесо модуляции";

            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                    basePlane.name = "Начальная плоскость";

                    offsetDef.direction = true;
                    offsetDef.offset = data.BodyHeight;
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

                        if (data.PanelWheel == WheelSetup.EnableFront)
                        {
                            sketchEdit.ksLineSeg(- 1.5, - 5.0, - 1.5, - 11.0,
                                1);
                            sketchEdit.ksLineSeg(- 1.5, - 11.0, - 3.5,
                                - 11.0, 1);
                            sketchEdit.ksLineSeg(- 3.5, - 11.0, - 3.5, - 5.0,
                                1);
                            sketchEdit.ksLineSeg(- 3.5, - 5.0, - 1.5, - 5.0,
                                1);
                        }
                        else if (data.PanelWheel == WheelSetup.EnableBack)
                        {
                            sketchEdit.ksLineSeg(- 1.5, - data.BodyDepth
                                + 11.0, - 1.5, - data.BodyDepth + 5.0, 1);
                            sketchEdit.ksLineSeg(- 1.5, - data.BodyDepth
                                + 5.0, - 3.5, - data.BodyDepth + 5.0, 1);
                            sketchEdit.ksLineSeg(- 3.5, - data.BodyDepth
                                + 5.0, - 3.5, - data.BodyDepth + 11.0, 1);
                            sketchEdit.ksLineSeg(-3.5, - data.BodyDepth
                                + 11.0, - 1.5, - data.BodyDepth + 11.0, 1);
                        }
                        sketchDef.EndEdit();
                        WhellSpaceCut(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод вырезания пространства для колеса модуляции.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void WhellSpaceCut(ksPart part, ksEntity entity)
        {
            var entityCut = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (entityCut != null)
            {
                entityCut.name = "Вырезание пространства для колеса модуляции";

                var cutDefinition = (ksCutExtrusionDefinition)entityCut.GetDefinition();
                if (cutDefinition != null)
                {
                    cutDefinition.directionType = (short)Direction_Type.dtNormal;
                    cutDefinition.SetSideParam(true, (short)End_Type.etBlind,
                        4.0);
                    cutDefinition.SetSketch(entity);

                    entityCut.Create();
                }
            }
        }

        /// <summary>
        /// Метод, создающий колесо модуляции.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void WheelBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            entitySketch.name = "Колесо модуляции";

            if (entityOffsetPlane != null)
            {
                var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDef != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);

                    basePlane.name = "Начальная плоскость";

                    offsetDef.direction = true;
                    offsetDef.offset = 1.5;
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

                        if (data.PanelWheel == WheelSetup.EnableFront)
                        {
                            sketchEdit.ksCircle(-data.BodyHeight + 1.0, 8.0,
                                3.0, 1);
                        }
                        else if (data.PanelWheel == WheelSetup.EnableBack)
                        {
                            sketchEdit.ksCircle(-data.BodyHeight + 1.0,
                                data.BodyDepth - 8.0, 3.0, 1);
                        }
                        sketchDef.EndEdit();
                        WheelExtruse(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод выдавливания колеса модуляции.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void WheelExtruse(ksPart part, ksEntity entity)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            if (entityExtrusion != null)
            {
                entityExtrusion.name = "Выдавливание колеса модуляции";

                var extrusionDefinition = (ksBossExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {

                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    extrusionDefinition.SetSideParam(true,
                        (short)End_Type.etBlind, 2.0);
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);

                    entityExtrusion.SetAdvancedColor(Color.FromArgb(80, 80,
                        80).ToArgb(), .0, .0, .0, .0, 100, 100);
                    entityExtrusion.Create();
                }
}
        }
    }
}
