interface IApiService
{
    get<T>(url: string, config: HttpRequestConfig, success: IWebResponseCallBack<T>, failure): any;
    post(url, data, success, failure): any;
    remove(url, success, failure): any;
}
