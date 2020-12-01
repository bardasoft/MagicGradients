﻿using Bogus;
using MagicGradients;
using Playground.Data.Repositories;
using Playground.Resources.Fonts;
using Playground.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using static Playground.Resources.Fonts.IcoMoonGlyph;
using Color = System.Drawing.Color;

namespace Playground.Features.BattleTest
{
    [QueryProperty("Id", "id")]
    public class BattleTestViewModel : ObservableObject
    {
        private readonly IGradientRepository _gradientRepository;
        private readonly IBattleItemService _battleItemService;

        private List<BattleItem> _iconsCollection;
        public List<BattleItem> IconsCollection
        {
            get => _iconsCollection;
            set => SetProperty(ref _iconsCollection, value);
        }

        private List<BattleItem> _itemsCollection;
        public List<BattleItem> ItemsCollection
        {
            get => _itemsCollection;
            set => SetProperty(ref _itemsCollection, value);
        }

        private string _id;
        public string Id //Don't remove it we set it from query
        {
            get => _id;
            set
            {
                _id = value;
                LoadCssCodeById();
            }
        }

        private Color _textColor;
        public Color TextColor
        {
            get => _textColor;
            set
            {
                if (SetProperty(ref _textColor, value))
                {
                    IconsCollection = GenerateIconsCollection();
                    ItemsCollection = GenerateItemsCollection();
                }
            }
        }

        private IGradientSource _gradientSource;
        public IGradientSource GradientSource
        {
            get => _gradientSource;
            set => SetProperty(ref _gradientSource, value);
        }

        private int _selectedColorIndex;
        public int SelectedColorIndex
        {
            get => _selectedColorIndex;
            set
            {
                if (SetProperty(ref _selectedColorIndex, value))
                {
                    TextColor = _battleItemService.GetColorByName(ColorNames[SelectedColorIndex]);
                }
            }
        }

        public List<string> ColorNames { get; }
        public ICommand ClickCommand { get; }
        public ICommand WithParameterCommand { get; }
        public ICommand DisabledCommand { get; }
        public string MagicButtonText { get; } = "My Content is bindable";

        public BattleTestViewModel(
            IGradientRepository gradientRepository, 
            IBattleItemService battleItemService)
        {
            _gradientRepository = gradientRepository;
            _battleItemService = battleItemService;

            ColorNames = _battleItemService.GetColorNames();
            TextColor = Color.White;
            ClickCommand = new Command(() =>
            {
                Application.Current.MainPage.DisplayAlert("","Button Clicked", "OK");
            });
            WithParameterCommand = new Command<Color>((color) =>
            {
                Application.Current.MainPage.DisplayAlert("", $"Text Color -> {color}", "OK");
            });
            DisabledCommand = new Command(() => { }, () => false);
        }

        private void LoadCssCodeById()
        {
            var gradient = _gradientRepository.GetById(int.Parse(Id));
            GradientSource = new CssGradientSource { Stylesheet = gradient.Stylesheet };
            IconsCollection = GenerateIconsCollection();
        }

        private List<BattleItem> GenerateIconsCollection()
        {
            var iconsCodeList = new List<string>
            {
               MagicWand, Refresh, IcoMoonGlyph.Gradient, IcoMoonGlyph.Radial,
               Palette, Layers, IcoMoonGlyph.Gallery, Code, Bolt, Paint
            };

            var battleItem = new Faker<BattleItem>()
                .RuleFor(item => item.Text, faker => faker.PickRandom(iconsCodeList))
                .RuleFor(item => item.TextColor, faker => TextColor)
                .RuleFor(item => item.GradientSource, faker => GradientSource);

            return _battleItemService.GenerateItems(battleItem, 15);
        }

        private List<BattleItem> GenerateItemsCollection()
        {
            var battleItem = new Faker<BattleItem>()
                .RuleFor(item => item.Text, (faker) => faker.Name.LastName())
                .RuleFor(item => item.TextColor, (faker) => TextColor);

            return _battleItemService.GenerateItems(battleItem, 90);
        }
    }
}
