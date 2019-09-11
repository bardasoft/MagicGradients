﻿using MagicGradients;
using Playground.Models;
using System.Collections.Generic;
using System.Linq;

namespace Playground.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly List<Gradient> _gradients;

        public GalleryService()
        {
            _gradients = new List<Gradient>
            {
                new Gradient
                {
                    Id = 1,
                    Source = new CssGradientSource
                    {
                        Stylesheet = "linear-gradient(71deg, rgba(55, 55, 55, 0.03) 0%, rgba(55, 55, 55, 0.03) 16.667%,rgba(111, 111, 111, 0.03) 16.667%, rgba(111, 111, 111, 0.03) 33.334%,rgba(230, 230, 230, 0.03) 33.334%, rgba(230, 230, 230, 0.03) 50.001000000000005%,rgba(129, 129, 129, 0.03) 50.001%, rgba(129, 129, 129, 0.03) 66.668%,rgba(77, 77, 77, 0.03) 66.668%, rgba(77, 77, 77, 0.03) 83.33500000000001%,rgba(190, 190, 190, 0.03) 83.335%, rgba(190, 190, 190, 0.03) 100.002%),linear-gradient(281deg, rgba(176, 176, 176, 0.03) 0%, rgba(176, 176, 176, 0.03) 16.667%,rgba(192, 192, 192, 0.03) 16.667%, rgba(192, 192, 192, 0.03) 33.334%,rgba(74, 74, 74, 0.03) 33.334%, rgba(74, 74, 74, 0.03) 50.001000000000005%,rgba(169, 169, 169, 0.03) 50.001%, rgba(169, 169, 169, 0.03) 66.668%,rgba(34, 34, 34, 0.03) 66.668%, rgba(34, 34, 34, 0.03) 83.33500000000001%,rgba(5, 5, 5, 0.03) 83.335%, rgba(5, 5, 5, 0.03) 100.002%),linear-gradient(196deg, rgba(98, 98, 98, 0.03) 0%, rgba(98, 98, 98, 0.03) 16.667%,rgba(208, 208, 208, 0.03) 16.667%, rgba(208, 208, 208, 0.03) 33.334%,rgba(63, 63, 63, 0.03) 33.334%, rgba(63, 63, 63, 0.03) 50.001000000000005%,rgba(180, 180, 180, 0.03) 50.001%, rgba(180, 180, 180, 0.03) 66.668%,rgba(200, 200, 200, 0.03) 66.668%, rgba(200, 200, 200, 0.03) 83.33500000000001%,rgba(59, 59, 59, 0.03) 83.335%, rgba(59, 59, 59, 0.03) 100.002%),linear-gradient(35deg, rgba(233, 233, 233, 0.03) 0%, rgba(233, 233, 233, 0.03) 16.667%,rgba(26, 26, 26, 0.03) 16.667%, rgba(26, 26, 26, 0.03) 33.334%,rgba(186, 186, 186, 0.03) 33.334%, rgba(186, 186, 186, 0.03) 50.001000000000005%,rgba(162, 162, 162, 0.03) 50.001%, rgba(162, 162, 162, 0.03) 66.668%,rgba(254, 254, 254, 0.03) 66.668%, rgba(254, 254, 254, 0.03) 83.33500000000001%,rgba(245, 245, 245, 0.03) 83.335%, rgba(245, 245, 245, 0.03) 100.002%),linear-gradient(294deg, rgba(157, 157, 157, 0.01) 0%, rgba(157, 157, 157, 0.01) 12.5%,rgba(125, 125, 125, 0.01) 12.5%, rgba(125, 125, 125, 0.01) 25%,rgba(120, 120, 120, 0.01) 25%, rgba(120, 120, 120, 0.01) 37.5%,rgba(19, 19, 19, 0.01) 37.5%, rgba(19, 19, 19, 0.01) 50%,rgba(111, 111, 111, 0.01) 50%, rgba(111, 111, 111, 0.01) 62.5%,rgba(140, 140, 140, 0.01) 62.5%, rgba(140, 140, 140, 0.01) 75%,rgba(114, 114, 114, 0.01) 75%, rgba(114, 114, 114, 0.01) 87.5%,rgba(94, 94, 94, 0.01) 87.5%, rgba(94, 94, 94, 0.01) 100%),linear-gradient(19deg, rgba(217, 217, 217, 0.02) 0%, rgba(217, 217, 217, 0.02) 20%,rgba(105, 105, 105, 0.02) 20%, rgba(105, 105, 105, 0.02) 40%,rgba(252, 252, 252, 0.02) 40%, rgba(252, 252, 252, 0.02) 60%,rgba(1, 1, 1, 0.02) 60%, rgba(1, 1, 1, 0.02) 80%,rgba(232, 232, 232, 0.02) 80%, rgba(232, 232, 232, 0.02) 100%),linear-gradient(90deg, rgb(22, 94, 235),rgb(126, 195, 9))"
                    }
                },
                new Gradient
                {
                    Id = 2, Source = new CssGradientSource
                    {
                        Stylesheet = "linear-gradient(135deg, rgba(249, 249, 249, 0.1) 0%, rgba(249, 249, 249, 0.1) 18%,rgba(70, 70, 70, 0.1) 18%, rgba(70, 70, 70, 0.1) 33%,rgba(229, 229, 229, 0.1) 33%, rgba(229, 229, 229, 0.1) 35%,rgba(53, 53, 53, 0.1) 35%, rgba(53, 53, 53, 0.1) 47%,rgba(156, 156, 156, 0.1) 47%, rgba(156, 156, 156, 0.1) 100%),linear-gradient(135deg, rgba(106, 106, 106, 0.08) 0%, rgba(106, 106, 106, 0.08) 9%,rgba(123, 123, 123, 0.08) 9%, rgba(123, 123, 123, 0.08) 10%,rgba(69, 69, 69, 0.08) 10%, rgba(69, 69, 69, 0.08) 38%,rgba(33, 33, 33, 0.08) 38%, rgba(33, 33, 33, 0.08) 65%,rgba(24, 24, 24, 0.08) 65%, rgba(24, 24, 24, 0.08) 77%,rgba(210, 210, 210, 0.08) 77%, rgba(210, 210, 210, 0.08) 100%),linear-gradient(45deg, rgba(70, 70, 70, 0.02) 0%, rgba(70, 70, 70, 0.02) 23%,rgba(225, 225, 225, 0.02) 23%, rgba(225, 225, 225, 0.02) 29%,rgba(118, 118, 118, 0.02) 29%, rgba(118, 118, 118, 0.02) 36%,rgba(28, 28, 28, 0.02) 36%, rgba(28, 28, 28, 0.02) 42%,rgba(142, 142, 142, 0.02) 42%, rgba(142, 142, 142, 0.02) 85%,rgba(95, 95, 95, 0.02) 85%, rgba(95, 95, 95, 0.02) 93%,rgba(32, 32, 32, 0.02) 93%, rgba(32, 32, 32, 0.02) 98%,rgba(71, 71, 71, 0.02) 98%, rgba(71, 71, 71, 0.02) 100%),linear-gradient(135deg, rgba(207, 207, 207, 0.05) 0%, rgba(207, 207, 207, 0.05) 12%,rgba(32, 32, 32, 0.05) 12%, rgba(32, 32, 32, 0.05) 27%,rgba(79, 79, 79, 0.05) 27%, rgba(79, 79, 79, 0.05) 32%,rgba(139, 139, 139, 0.05) 32%, rgba(139, 139, 139, 0.05) 43%,rgba(150, 150, 150, 0.05) 43%, rgba(150, 150, 150, 0.05) 79%,rgba(139, 139, 139, 0.05) 79%, rgba(139, 139, 139, 0.05) 87%,rgba(55, 55, 55, 0.05) 87%, rgba(55, 55, 55, 0.05) 91%,rgba(68, 68, 68, 0.05) 91%, rgba(68, 68, 68, 0.05) 100%),linear-gradient(0deg, rgba(108, 108, 108, 0.1) 0%, rgba(108, 108, 108, 0.1) 16%,rgba(163, 163, 163, 0.1) 16%, rgba(163, 163, 163, 0.1) 18%,rgba(32, 32, 32, 0.1) 18%, rgba(32, 32, 32, 0.1) 29%,rgba(122, 122, 122, 0.1) 29%, rgba(122, 122, 122, 0.1) 61%,rgba(141, 141, 141, 0.1) 61%, rgba(141, 141, 141, 0.1) 67%,rgba(53, 53, 53, 0.1) 67%, rgba(53, 53, 53, 0.1) 78%,rgba(142, 142, 142, 0.1) 78%, rgba(142, 142, 142, 0.1) 100%),linear-gradient(0deg, rgba(160, 160, 160, 0.08) 0%, rgba(160, 160, 160, 0.08) 27%,rgba(163, 163, 163, 0.08) 27%, rgba(163, 163, 163, 0.08) 29%,rgba(37, 37, 37, 0.08) 29%, rgba(37, 37, 37, 0.08) 35%,rgba(96, 96, 96, 0.08) 35%, rgba(96, 96, 96, 0.08) 73%,rgba(250, 250, 250, 0.08) 73%, rgba(250, 250, 250, 0.08) 90%,rgba(91, 91, 91, 0.08) 90%, rgba(91, 91, 91, 0.08) 100%),linear-gradient(90deg, rgba(191, 191, 191, 0.08) 0%, rgba(191, 191, 191, 0.08) 2%,rgba(170, 170, 170, 0.08) 2%, rgba(170, 170, 170, 0.08) 7%,rgba(49, 49, 49, 0.08) 7%, rgba(49, 49, 49, 0.08) 9%,rgba(131, 131, 131, 0.08) 9%, rgba(131, 131, 131, 0.08) 23%,rgba(197, 197, 197, 0.08) 23%, rgba(197, 197, 197, 0.08) 29%,rgba(154, 154, 154, 0.08) 29%, rgba(154, 154, 154, 0.08) 91%,rgba(211, 211, 211, 0.08) 91%, rgba(211, 211, 211, 0.08) 100%),linear-gradient(90deg, rgb(45, 83, 160),rgb(21, 228, 112))"
                    }
                }
            };
        }

        public List<Gradient> GetGradients()
        {
            return _gradients;
        }

        public Gradient GetGradientById(int id)
        {
            return _gradients.FirstOrDefault(x => x.Id == id);
        }
    }
}
