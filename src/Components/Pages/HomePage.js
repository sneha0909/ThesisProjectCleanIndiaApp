import React, { useEffect } from "react";
import Navbar1 from '../Navbar1/Navbar1';
import Navbar2 from '../Navbar2/Navbar2';
import ImageSlider from '../Image Slider/ImageSlider';
import images from '../Image Slider/images';
import Pledge1 from '../MiddlePart1/Pledge1';
import Footer from '../Footer/Footer';
import Cards from '../MiddlePart3/Cards';

function HomePage() {



  return (

    <>
      <div className="light-theme">
        <Navbar1 />
        <Navbar2 />
        <ImageSlider images={images} />
        <Pledge1 />
        <Cards />
        <Footer />

      </div>



    </>

  );
}

export default HomePage;