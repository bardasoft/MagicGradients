﻿namespace GradientsApp.Infrastructure
{
    public interface INavigationAware
    {
        void Prepare();
    }

    public interface INavigationAware<TParameter>
    {
        void Prepare(TParameter parameter);
    }

    public interface IHaveTitle
    {
        string Title { get; }
    }
}