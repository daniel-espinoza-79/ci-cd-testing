import withPWA from "next-pwa";

/** @type {import('next').NextConfig} */
const nextConfig = {
  typescript: {
    ignoreBuildErrors: true,
  },
  reactStrictMode: true
};

export default withPWA({
  dest: "public"
})(nextConfig);
