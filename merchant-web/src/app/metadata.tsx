import type {Metadata} from "next";

export const metadata: Metadata = {
  title: "Merchant - Your Online Store for Quality Products",
  description:
    "Discover a wide variety of quality products at Merchant. Shop online for electronics, fashion, home goods, and more. Enjoy fast shipping and excellent customer service!",
  keywords: [
    "e-commerce",
    "online store",
    "shopping",
    "electronics",
    "fashion",
    "home goods",
    "quality products",
    "fast shipping",
    "customer service",
  ],
  authors: {
    name: "The Microbugazos Team",
  },
  robots: "index, follow",
  manifest: "public/manifest.json",
  viewport:
    "minimum-scale=1, initial-scale=1, width=device-width, shrink-to-fit=no, viewport-fit=cover",
  icons: [
    { rel: "apple-touch-icon", url: "icons-128.png" },
    { rel: "icon", url: "icons-128.png" },
  ]
};
