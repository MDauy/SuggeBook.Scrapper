﻿//using HtmlAgilityPack;
//using System;
//using System.Net.Http;
//using System.Text.RegularExpressions;
//using System.Threading;
//using System.Threading.Tasks;

//namespace SuggeBookScrapper
//{
//    public class BabelioScrapper
//    {
//        private LivraddictScrapper _scrapper;
//        public BabelioScrapper()
//        {
//            _scrapper = new LivraddictScrapper();
//        }

//        public async Task Scrapp()
//        {
//            var index = 2538;

//            var baseUrl = "https://www.babelio.com/auteur/xx/";
//            var handler = new HttpClientHandler();

//            using (handler)
//            {
//                handler.AllowAutoRedirect = true;
//                using (HttpClient httpClient = new HttpClient(handler))
//                    while (index < 7000)
//                    {
//                        Thread.Sleep(3000);
//                        var url = $"{baseUrl}{index}";
//                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
//                        using (var response = await httpClient.SendAsync(request))
//                        {
//                            //checker response.RequestMessage
//                            var uri = response.RequestMessage.RequestUri;
//                            if (string.Equals(uri, "https://www.babelio.com/"))
//                            {
//                                index++;
//                                continue;
//                            }
//                            else
//                            {
//                                using (var content = await httpClient.GetAsync(uri))
//                                {
//                                    if (content == null || content.StatusCode != System.Net.HttpStatusCode.OK)
//                                    {
//                                        await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.REGISTER_MISSED_AUTHOR, uri.ToString());
//                                    }
//                                    try
//                                    {
//                                        var htmlDocument = new HtmlDocument();
//                                        var pageContent = await content.Content.ReadAsStringAsync();
//                                        if (pageContent != null)
//                                        {
//                                            htmlDocument.LoadHtml(pageContent);
//                                            var authorNameTags = htmlDocument.DocumentNode.SelectSingleNode("(//div[contains(@class, 'livre_header_con')]//h1//a)[1]");

//                                            if (authorNameTags != null)
//                                            {
//                                                var name = Regex.Replace(authorNameTags.InnerHtml, @"\t|\n|\r", "");
//                                                await _scrapper.ScrappAuthorPage(name);
//                                            }
//                                        }
//                                    }
//                                    catch (Exception ex)
//                                    {
//                                        await UrlCallerHelper.CallUri_StringResult(HttpMethod.Post, ApiUrls.REGISTER_MISSED_AUTHOR, $"Scrapping on : {uri.ToString()} : {ex.Message}");
//                                    }
//                                }
//                                index++;
//                            }
//                        }
//                    }
//            }

//        }


//    }
//}
