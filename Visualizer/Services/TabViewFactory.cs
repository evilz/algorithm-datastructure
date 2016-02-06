using System;
using System.Collections.Generic;
using System.Windows;
using Dragablz;
using Visualizer.Visualizers;

namespace Visualizer.Services
{

    public enum VisualizerType
    {
        Pathfinding,
        Set,
        Sort,
    }

    public static class TabViewFactory
    {
        public static readonly Dictionary<VisualizerType, Func<Size, HeaderedItemViewModel>> VisualizerTypeViews = new Dictionary
            <VisualizerType, Func<Size, HeaderedItemViewModel>>
        {
            {VisualizerType.Pathfinding, (gridSize) => new PathfindingViewModel(gridSize)},
        };
    }
}

