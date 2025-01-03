# News API for Khmer News - Fetch Data from FreshNews

This repository provides an API for accessing up-to-date news data from various Khmer news sources, with data fetched directly from FreshNews. The API allows developers to retrieve news articles and seamlessly integrate the data into their applications or services.

## API Endpoint

To access the News API, use the following endpoint:

+ List all news
```
http://news.somee.com/api/news/get
```
+ Show detail
```
http://news.somee.com/api/news/show?link={link}
```

## Paginated Results

To retrieve additional pages of news articles, append `?page=` followed by the desired page number to the API endpoint. For example, to retrieve the second page of results, use the following URL:

```
http://news.somee.com/api/news/get?page=2
```

## Total Pages

The API provides a total of 20 pages of news articles. You can navigate through the available pages by specifying the desired page number using the `?page=` parameter.


---

**Disclaimer:** This API is not affiliated with [FreshNews](https://freshnewsasia.com/index.php/en/ "FreshNews's Website"). The data presented is sourced from FreshNews and made available via this API for educational and development purposes.


