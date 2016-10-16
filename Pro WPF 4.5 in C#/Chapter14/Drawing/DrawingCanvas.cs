using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Drawing
{
    public class DrawingCanvas : Panel
    {
        private List<Visual> visuals = new List<Visual>();

        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }

        public void AddVisual(Visual visual)
        {
            visuals.Add(visual);

            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void DeleteVisual(Visual visual)
        {
            visuals.Remove(visual);

            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);            
        }

        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as DrawingVisual;            
        }

        private List<DrawingVisual> hits = new List<DrawingVisual>();
        public List<DrawingVisual> GetVisuals(Geometry region)
        {
            hits.Clear();
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(this.HitTestCallback);
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return hits;
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            DrawingVisual visual = result.VisualHit as DrawingVisual;
            if (visual != null &&
                geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
            {
                hits.Add(visual);
            }
            return HitTestResultBehavior.Continue;
        }

    }
}
