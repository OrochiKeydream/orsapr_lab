using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasKeyboardPlugin
{
    /// <summary>
    /// Класс, создающий тело клавиатуры.
    /// </summary>
    class BodyCreator : KeyboardPartBase
    {
        /// <summary>
        /// Метод, создающий тело клавиатуры.
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="data"></param>
        public override void Build(ksDocument3D document3D,
            KeyboardParametersStorage data)
        {
            part = (ksPart)document3D.GetPart((short)Part_Type.pTop_Part);
            if (part != null)
            {
                // НИЖНЯЯ часть тела клавиатуры.
                //
                var entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                if (entitySketch != null)
                {
                    entitySketch.name = "Тело клавиатуры";

                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

                        sketchDef.SetPlane(basePlane);
                        entitySketch.Create();

                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        sketchEdit.ksLineSeg(0, 0, 0, - data.BodyDepth, 1);
                        sketchEdit.ksLineSeg(0, - data.BodyDepth,
                            - data.BodyLength, - data.BodyDepth, 1);
                        sketchEdit.ksLineSeg(- data.BodyLength,
                            - data.BodyDepth, -data.BodyLength, 0, 1);
                        sketchEdit.ksLineSeg(- data.BodyLength, 0, 0, 0, 1);

                        sketchDef.EndEdit();
                        BodyExtruseBottom(data, entitySketch);
                    }
                }
                // ВЕРХНЯЯ часть тела клавиатуры.
                //
                var entityOffsetPlane = (ksEntity)part.NewEntity((short)Obj3dType.o3d_planeOffset);

                entitySketch = (ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
                if (entityOffsetPlane != null)
                {
                    entitySketch.name = "Тело клавиатуры";

                    var offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                    if (offsetDef != null)
                    {
                        var basePlane = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                        basePlane.name = "Начальная плоскость";

                        offsetDef.direction = true;
                        offsetDef.offset = data.BodyHeight - 3.5;
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

                            sketchEdit.ksLineSeg(0, 0, 0, - data.BodyDepth,
                                1);
                            sketchEdit.ksLineSeg(0, - data.BodyDepth,
                                - data.BodyLength, - data.BodyDepth, 1);
                            sketchEdit.ksLineSeg(- data.BodyLength,
                                - data.BodyDepth, - data.BodyLength, 0, 1);
                            sketchEdit.ksLineSeg(- data.BodyLength, 0,
                                - (data.BodyLength / 2)
                                - (data.BoardLength / 2), 0, 1);
                            sketchEdit.ksLineSeg(- (data.BodyLength / 2)
                                - (data.BoardLength / 2), 0,
                                - (data.BodyLength / 2)
                                - (data.BoardLength / 2), - 15.5, 1);
                            sketchEdit.ksLineSeg(- (data.BodyLength / 2)
                                - (data.BoardLength / 2), - 15.5,
                                - (data.BodyLength / 2)+ (data.BoardLength
                                / 2), -15.5, 1);
                            sketchEdit.ksLineSeg(- (data.BodyLength / 2)
                                + (data.BoardLength / 2), - 15.5,
                                - (data.BodyLength / 2) + (data.BoardLength
                                / 2), 0, 1);
                            sketchEdit.ksLineSeg(- (data.BodyLength / 2)
                                + (data.BoardLength / 2), 0, 0, 0, 1);

                            sketchDef.EndEdit();
                            BodyExtruseTop(data, entitySketch);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод выдавливания нижней части тела клавиатуры.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="entity"></param>
        private void BodyExtruseBottom(KeyboardParametersStorage data,
            ksEntity entity)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtrusion != null)
            {
                entityExtrusion.name = "Выдавливание тела";

                var extrusionDefinition = (ksBaseExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {
                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    extrusionDefinition.SetSideParam(true,
                        (short)End_Type.etBlind, data.BodyHeight - 3.5);
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);

                    entityExtrusion.SetAdvancedColor(Color.FromArgb(120, 120, 120).ToArgb(),
                        .0, .0, .0, .0, 100, 100);
                    entityExtrusion.Create();
                }
            }
        }

        /// <summary>
        /// Метод выдавливания верхней части тела клавиатуры.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="entity"></param>
        private void BodyExtruseTop(KeyboardParametersStorage data,
            ksEntity entity)
        {
            var entityExtrusion = (ksEntity)part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtrusion != null)
            {
                entityExtrusion.name = "Выдавливание тела";

                var extrusionDefinition = (ksBaseExtrusionDefinition)entityExtrusion.GetDefinition();
                if (extrusionDefinition != null)
                {
                    extrusionDefinition.directionType = (short)Direction_Type.dtNormal;
                    extrusionDefinition.SetSideParam(true,
                        (short)End_Type.etBlind, data.BodyHeight -
                        (data.BodyHeight - 3.5));
                    extrusionDefinition.SetThinParam(false, 0, 0, 0);
                    extrusionDefinition.SetSketch(entity);

                    entityExtrusion.SetAdvancedColor(Color.FromArgb(120, 120, 120).ToArgb(),
                        .0, .0, .0, .0, 100, 100);
                    entityExtrusion.Create();
                }
            }
        }
    }
}
