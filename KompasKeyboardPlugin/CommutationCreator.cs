using Kompas6API5;
using Kompas6Constants3D;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, создающий коммутационную панель.
    /// </summary>
    public class CommutationCreator : KeyboardPartBase
    {
        /// <summary>
        /// Динамически изменяющийся отступ.
        /// </summary>
        private double _margin = 20.0;

        /// <summary>
        /// Метод построения коммутационной панели.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        public override void Build(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            int countXLR = data.CommutationXLR;
            int countTRS = data.CommutationTRS;
            int countMIDI = data.CommutationMIDI;

            XLRBuild(document3D, data);
            TRSBuild(document3D, data);
            MIDIBuild(document3D, data);
        }

        /// <summary>
        /// Метод построения разъемов XLR.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void XLRBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            entitySketch.name = "Разъемы XLR";
            if (entityOffsetPlane != null)
            {
                var offsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDefinition != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                    basePlane.name = "Начальная плоскость";

                    offsetDefinition.direction = false;
                    offsetDefinition.offset = data.BodyDepth;
                    offsetDefinition.SetPlane(basePlane);

                    entityOffsetPlane.name = "Смещенная плоскость";
                    entityOffsetPlane.hidden = true;
                    entityOffsetPlane.Create();

                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        sketchDef.SetPlane(entityOffsetPlane);
                        entitySketch.Create();

                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
                        for (int i = 0; i < data.CommutationXLR; i++)
                        {
                            sketchEdit.ksCircle(-(_margin), -2.5, 0.75, 1);
                            sketchEdit.ksCircle(-(_margin) - 0.375, -2.5,
                                0.1, 1);
                            sketchEdit.ksCircle(-(_margin), -2.875, 0.1, 1);
                            sketchEdit.ksCircle(-(_margin) + 0.375, -2.5,
                                0.1, 1);

                            // Производим обновление отступа для следующего
                            // разъема.
                            _margin += 2.5;
                        }
                        sketchDef.EndEdit();
                        CutXLR(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод построения разъемов TRS.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void TRSBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
            entitySketch.name = "Разъемы TRS";

            if (entityOffsetPlane != null)
            {
                var offsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDefinition != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                    basePlane.name = "Начальная плоскость";

                    offsetDefinition.direction = false;
                    offsetDefinition.offset = data.BodyDepth;
                    offsetDefinition.SetPlane(basePlane);

                    entityOffsetPlane.name = "Смещенная плоскость";
                    entityOffsetPlane.hidden = true;
                    entityOffsetPlane.Create();

                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        sketchDef.SetPlane(entityOffsetPlane);

                        entitySketch.Create();

                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        for (int i = 0; i < data.CommutationTRS; i++)
                        {
                            sketchEdit.ksCircle(-(_margin), -2.5, 0.4, 1);

                            // Производим обновление отступа для следующего
                            // разъема.
                            _margin += 2.5;
                        }
                        sketchDef.EndEdit();
                        CutTRS(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод построения разъемов MIDI.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        private void MIDIBuild(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);

            var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);

            entitySketch.name = "Разъемы MIDI";

            if (entityOffsetPlane != null)
            {
                var offsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                if (offsetDefinition != null)
                {
                    var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                    basePlane.name = "Начальная плоскость";

                    offsetDefinition.direction = false;
                    offsetDefinition.offset = data.BodyDepth;
                    offsetDefinition.SetPlane(basePlane);

                    entityOffsetPlane.name = "Смещенная плоскость";
                    entityOffsetPlane.hidden = true;
                    entityOffsetPlane.Create();

                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        sketchDef.SetPlane(entityOffsetPlane);
                        entitySketch.Create();

                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        for (int i = 0; i < data.CommutationMIDI; i++)
                        {
                            sketchEdit.ksCircle(-(_margin), -2.5, 0.75, 1);
                            sketchEdit.ksCircle(-(_margin), -2.5, 0.7, 1);


                            sketchEdit.ksCircle(-(_margin) - 0.350, -2.5,
                                0.05, 1);
                            sketchEdit.ksCircle(-(_margin) - 0.2625, -2.2375,
                                0.05, 1);
                            sketchEdit.ksCircle(-(_margin), -2.150, 0.05, 1);
                            sketchEdit.ksCircle(-(_margin) + 0.2625, -2.2375,
                                0.05, 1);
                            sketchEdit.ksCircle(-(_margin) + 0.350, -2.5,
                                0.05, 1);

                            // Производим обновление отступа для следующего
                            // разъема.
                            _margin += 2.5;
                        }
                        sketchDef.EndEdit();
                        CutMIDI(part, entitySketch);
                    }
                }
            }
        }

        /// <summary>
        /// Метод вырезания разъемов XLR.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void CutXLR(ksPart part, ksEntity entity)
        {
            var entityCut = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (entityCut != null)
            {
                entityCut.name = "Вырезание разъемов XLR";

                var cutDefinition = (ksCutExtrusionDefinition)entityCut.GetDefinition();
                if (cutDefinition != null)
                {
                    cutDefinition.directionType = (short)Direction_Type.dtReverse;
                    cutDefinition.SetSideParam(false,
                        (short)End_Type.etBlind, 2.0);
                    cutDefinition.SetSketch(entity);

                    entityCut.Create();
                }
            }
        }

        /// <summary>
        /// Метод вырезания разъемов TRS.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void CutTRS(ksPart part, ksEntity entity)
        {
            var entityCut = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (entityCut != null)
            {
                entityCut.name = "Вырезание разъемов TRS";

                var cutDefinition = (ksCutExtrusionDefinition)entityCut.GetDefinition();
                if (cutDefinition != null)
                {
                    cutDefinition.directionType = (short)Direction_Type.dtReverse;
                    cutDefinition.SetSideParam(false,
                        (short)End_Type.etBlind, 3.0);
                    cutDefinition.SetSketch(entity);

                    entityCut.Create();
                }
            }
        }

        /// <summary>
        /// Метод вырезания разъемов MIDI.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="entity"></param>
        private void CutMIDI(ksPart part, ksEntity entity)
        {
            var entityCut = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (entityCut != null)
            {
                entityCut.name = "Вырезание разъемов MIDI";

                var cutDefinition = (ksCutExtrusionDefinition)entityCut.GetDefinition();
                if (cutDefinition != null)
                {
                    cutDefinition.directionType = (short)Direction_Type.dtReverse;
                    cutDefinition.SetSideParam(false,
                        (short)End_Type.etBlind, 3.0);
                    cutDefinition.SetSketch(entity);

                    entityCut.Create();
                }
            }
        }
    }
}
